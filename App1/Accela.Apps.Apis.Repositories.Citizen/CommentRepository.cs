
using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Common;


namespace Accela.Apps.Apis.Repositories.Citizen
{
    public class CommentRepository : RepositoryBase, ICommentRepository
    {
        /// <summary>
        /// Get comments.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="appID">AppID.</param>        
        /// <param name="globalEntityID">GlobalEntityID.</param>
        /// <returns>CitizenCommentModel list.</returns>
        public List<CitizenCommentModel> GetComments(int start, int end, Guid globalEntityID, string appID)
        {
            return GetCommentsImp(globalEntityID, appID, start, end);
        }

        /// <summary>
        /// Get Top Comments.
        /// </summary>
        /// <param name="offSet">OffSet</param>
        /// <param name="limit">Limit</param>
        /// <param name="globalEntityID">GlobalEntityID.</param>
        /// <returns>CitizenCommentModel list.</returns>
        public List<CitizenCommentModel> GetTopComments(int offSet, int limit, Guid globalEntityID)
        {
            return GetCommentsImp(globalEntityID, null, offSet, limit);
        }

        private List<CitizenCommentModel> GetCommentsImp(Guid globalEntityID, string appID, int offset, int limit)
        {
            var citizenCommentModels = new List<CitizenCommentModel>();

            //using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            //{
            //    var commentsQuery = (from comment in apiDataContext.Comments
            //                         where comment.GlobalEntityID == globalEntityID
            //                         orderby comment.CreatedDate descending
            //                         select new CitizenCommentModel
            //                         {
            //                             ID = comment.ID,
            //                             Comment = comment.Comments1,
            //                             AppID = comment.AppID,
            //                             CloudUserId = comment.CloudUserId,
            //                             CreatedBy = comment.CreatedBy,
            //                             CreatedDate = comment.CreatedDate ?? comment.CreatedDate.Value
            //                         }).Skip(offset).Take(limit);

            //    if (!String.IsNullOrEmpty(appID))
            //    {
            //        commentsQuery.Where(item => item.AppID == appID);
            //    }

            //    SqlRetryPolicy.ExecuteAction(() =>
            //    {
            //        citizenCommentModels.AddRange(commentsQuery.ToList());
            //    });
            //}

            return citizenCommentModels;
        }

        public int GetCommentsCount(Guid globalEntityID)
        {
            int Count = 0;
            //using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            //{
            //    SqlRetryPolicy.ExecuteAction(() =>
            //    {
            //        Count = apiDataContext.Comments.Where(c => c.GlobalEntityID == globalEntityID).Count();
            //    });
            //}

            return Count;
        }

        /// <summary>
        /// Add comment.
        /// </summary>
        /// <param name="globalEntityID">GlobalEntityID.</param>        
        /// <param name="comment">Comment.</param>
        /// <param name="appID">AppID.</param>
        /// <param name="cloudUserId">Cloud User Id.</param>
        /// <returns>CitizenCommentModel.</returns>
        public CitizenCommentModel Add(Guid globalEntityID, string comment, Guid cloudUserId,string createdBy, string appID, out int userCommmentCount)
        {
            var citizenCommentModel = new CitizenCommentModel();
            //var commentDB = new Accela.Apps.Apis.Persistence.Comment();

            //using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            //{
            //    commentDB.ID = Guid.NewGuid();
            //    commentDB.GlobalEntityID = globalEntityID;
            //    commentDB.Comments1 = comment;
            //    commentDB.AppID = appID;
            //    commentDB.CloudUserId = cloudUserId;
            //    commentDB.CreatedBy = createdBy;
            //    commentDB.CreatedDate = DateTime.UtcNow;

            //    apiDataContext.Comments.Add(commentDB);

            //    SqlRetryPolicy.ExecuteAction(() =>
            //    {
            //        apiDataContext.SaveChanges();
            //    });

            userCommmentCount = 0;
            //        apiDataContext.Comments.Count(x => x.GlobalEntityID == globalEntityID);
            //}

            //citizenCommentModel.ID = commentDB.ID;
            //citizenCommentModel.GlobalEntityID = commentDB.GlobalEntityID;
            //citizenCommentModel.Comment = commentDB.Comments1;
            //citizenCommentModel.AppID = commentDB.AppID;
            //citizenCommentModel.CloudUserId = commentDB.CloudUserId;
            //citizenCommentModel.CreatedBy = commentDB.CreatedBy;
            //citizenCommentModel.CreatedDate = commentDB.CreatedDate.Value;

            return citizenCommentModel;
        }
    }
}
