using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Shared.FormatHelpers;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class InspectionCommentsHelper : GovXmlHelperBase 
    {
        /// <summary>
        /// old format row start pattern
        /// </summary>
        const string OLD_FORMAT_ROW_START_PATTERN = @"^\s*----\((?<datetime>\d{4}-\d{1,2}-\d{1,2}\s*(\d{1,2}:\d{1,2}(:\d{1,2})?)?)\)\[(?<name>[^\]]*?)\]----\s*$";

        /// <summary>
        /// old format row end string
        /// </summary>
        const string OLD_FORMAT_ROW_END_STRING = @"^\s*----End----\s*$";

        /// <summary>
        /// Builds the comments for update.
        /// </summary>
        /// <param name="commentList">The comment list.</param>
        /// <returns>the comments for update.</returns>
        internal static string BuildComments4Update(List<Comment> commentList)
        {
            string lineBreak = "\r\n";
            string result = "";
            string dateLabel = "Date";
            string pattern = "{0}: {1}{2}{3}{4}";

            if (commentList != null)
            {
                var uiDateformat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

                foreach (var comment in commentList)
                {
                    if (result != "")
                    {
                        result += lineBreak;
                    }

                    string currentDateText = comment.FillDate;

                    try
                    {
                        currentDateText = DateTimeFormat.ToUIDateStringFromMetaDateString(comment.FillDate, uiDateformat);
                    }
                    catch { }

                    result += String.Format(pattern, dateLabel, currentDateText, lineBreak, comment.Content, lineBreak);
                }
            }

            return result;
        }

        /// <summary>
        /// Extracts the customized comments.
        /// </summary>
        /// <param name="commentList">The comment list.</param>
        /// <returns>the customized comments.</returns>
        internal static List<Comment> ExtractCustomizedComments(string commentString, string fillDate, string owner)
        {
            List<Comment> result = null;

            if (!String.IsNullOrWhiteSpace(commentString))
            {
                bool isUsingOldFormat = IsUsingOldFormat(commentString, fillDate, owner);

                if (isUsingOldFormat)
                {
                    result = ExtractCustomizedOldFormatComments(commentString, fillDate, owner);
                }
                else
                {
                    result = ExtractCustomizedNewFormatComments(commentString, fillDate, owner);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is using old format] [the specified comment string].
        /// </summary>
        /// <param name="commentString">The comment string.</param>
        /// <param name="fillDate">The fill date.</param>
        /// <param name="owner">The owner.</param>
        /// <returns>
        /// <c>true</c> if [is using old format] [the specified comment string]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsUsingOldFormat(string commentString, string fillDate, string owner)
        {
            bool result = false;
            Regex rowStartRegex = new Regex(OLD_FORMAT_ROW_START_PATTERN, RegexOptions.Multiline | RegexOptions.Compiled);
            MatchCollection startMatches = rowStartRegex.Matches(commentString);

            result = startMatches.Count >= 1;

            return result;
        }

        /// <summary>
        /// Extracts the customized comments.
        /// scenarios:
        /// 1. standard pattern, e.g.
        ///    [comment header line]
        ///    comment 1
        ///    [comment header line]
        ///    comment 2
        /// 2. no comment header line in the string, e.g.
        ///    comment 1
        /// 3. no comment header line in the first line, e.g.
        ///    comment 1
        ///    [comment header line]
        ///    comment 2
        /// 4. comment is empty, e.g.
        ///    [empty string]
        /// 5. only comment header line, e.g.
        ///    [comment header line]
        /// </summary>
        /// <param name="commentList">The comment list.</param>
        /// <returns>the customized comments list.</returns>
        private static List<Comment> ExtractCustomizedNewFormatComments(string commentString, string fillDate, string owner)
        {
            List<Comment> result = null;
            string lineBreak1 = "\r\n";
            string lineBreak2 = "\n";
            //string dateLabel = MobileResources.GetString("Repositories_InspectionComment_Date");
            string dateLabel = "Date";
            string commentHeaderStartString = String.Format("{0}: ", dateLabel);

            if (!string.IsNullOrWhiteSpace(commentString))
            {
                result = new List<Comment>();
                string[] commentLines = commentString.Split(new string[] { lineBreak1, lineBreak2 }, StringSplitOptions.None);
                StringBuilder commentBuilder = new StringBuilder();
                DateTime? lastDate = null;
                DateTime? currentDate = null;
                bool isReadyToBuildComment = false;

                for (int i = 0; i < commentLines.Length; i++)
                {
                    string currentLine = commentLines[i];

                    //check to seee if current line is the separated line
                    if (!String.IsNullOrWhiteSpace(currentLine) && currentLine.StartsWith(commentHeaderStartString))
                    {
                        lastDate = currentDate;
                        //get current date
                        string currentDateString = currentLine.Replace(commentHeaderStartString, "").Trim();
                        try
                        {
                            currentDate = !String.IsNullOrWhiteSpace(currentDateString) ? DateTimeFormat.ToDateTimeFromUIDateTimeString(currentDateString) : (DateTime?)null;
                        }
                        catch { }

                        //if stringBuilder has value, set isReadyToBuildComment to true
                        if (commentBuilder.Length > 0)
                        {
                            isReadyToBuildComment = true;
                        }
                    }
                    else if (!String.IsNullOrWhiteSpace(currentLine))
                    {
                        var currentLineBreak = commentBuilder.Length > 0 ? lineBreak1 : String.Empty;
                        commentBuilder.AppendFormat("{0}{1}", currentLineBreak, currentLine);
                    }

                    //if current line reaches to the end and stringBuilder has value, set isReadyToBuildComment to true
                    if (i == commentLines.Length - 1 && commentBuilder.Length > 0)
                    {
                        lastDate = currentDate;
                        isReadyToBuildComment = true;
                    }

                    //create new comment and init stringbuilder.
                    if (isReadyToBuildComment)
                    {
                        var currentComment = new Comment();
                        currentComment.Content = commentBuilder.ToString();
                        currentComment.FillDate = lastDate == null ? fillDate : DateTimeFormat.ToMetaDateTimeString(lastDate.Value);
                        currentComment.FillPeopleName = owner;
                        result.Add(currentComment);
                        commentBuilder = new StringBuilder();
                        isReadyToBuildComment = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Extracts the customized old style comments.
        /// </summary>
        /// <param name="commentString">The comment string.</param>
        /// <param name="fillDate">The fill date.</param>
        /// <param name="owner">The owner.</param>
        /// <returns>the customized comments list.</returns>
        private static List<Comment> ExtractCustomizedOldFormatComments(string commentString, string fillDate, string owner)
        {
            List<Comment> result = null;

            if (!string.IsNullOrWhiteSpace(commentString))
            {
                result = new List<Comment>();

                Regex rowStartRegex = new Regex(OLD_FORMAT_ROW_START_PATTERN, RegexOptions.Multiline | RegexOptions.Compiled);
                Regex rowEndRegex = new Regex(OLD_FORMAT_ROW_END_STRING, RegexOptions.Multiline | RegexOptions.Compiled);

                MatchCollection startMatches = rowStartRegex.Matches(commentString);
                MatchCollection endMatches = rowEndRegex.Matches(commentString);

                int processPosition = 0;
                for (int i = 0; i < startMatches.Count; i++)
                {
                    Match startMatch = startMatches[i];
                    if (startMatch.Index != processPosition)
                    {
                        string tem = commentString.Substring(processPosition, startMatch.Index - processPosition);
                        if (!string.IsNullOrWhiteSpace(tem))
                        {
                            var newComment = new Comment();
                            newComment.Content = tem.Trim();
                            newComment.FillDate = fillDate;
                            newComment.FillPeopleName = owner;
                            result.Add(newComment);
                        }
                    }

                    int nextStartMatchIndex = commentString.Length;
                    if (i != startMatches.Count - 1)
                    {
                        nextStartMatchIndex = startMatches[i + 1].Index - 1;
                    }

                    Match findEndMatch = null;
                    //to find the end string
                    for (int j = 0; j < endMatches.Count; j++)
                    {
                        Match endMatch = endMatches[j];
                        if (endMatch.Index > startMatch.Index)
                        {
                            if (nextStartMatchIndex > endMatch.Index)
                            {
                                findEndMatch = endMatch;
                            }
                            break;
                        }
                    }

                    int endIndex = nextStartMatchIndex;
                    if (findEndMatch != null)
                    {
                        endIndex = findEndMatch.Index - 1;
                        processPosition = findEndMatch.Index + findEndMatch.Length;
                    }
                    else
                    {
                        processPosition = endIndex;
                    }

                    string tem_comment = commentString.Substring(startMatch.Index + startMatch.Length, endIndex - startMatch.Index - startMatch.Length);
                    if (!string.IsNullOrWhiteSpace(tem_comment))
                    {
                        var newComment = new Comment();
                        newComment.Content = tem_comment.Trim();
                        newComment.FillDate = startMatch.Groups["datetime"].Value;
                        newComment.FillPeopleName = startMatch.Groups["name"].Value;
                        result.Add(newComment);
                    }

                    //check the last comments
                    if (i == startMatches.Count - 1)
                    {
                        if (processPosition != commentString.Length)
                        {
                            string tem = commentString.Substring(processPosition, commentString.Length - processPosition);
                            if (!string.IsNullOrWhiteSpace(tem))
                            {
                                var newComment = new Comment();
                                newComment.Content = tem.Trim();
                                newComment.FillDate = fillDate;
                                newComment.FillPeopleName = owner;
                                result.Add(newComment);
                            }
                        }
                    }
                }

                if (startMatches.Count == 0)
                {
                    var newComment = new Comment();
                    newComment.Content = commentString;
                    newComment.FillDate = fillDate;
                    newComment.FillPeopleName = owner;
                    result.Add(newComment);
                }
            }

            return result;
        }
    }
}
