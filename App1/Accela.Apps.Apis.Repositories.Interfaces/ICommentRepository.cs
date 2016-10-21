using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository
    {
        /// <summary>
        /// Get comments.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="appID">AppID.</param>        
        /// <param name="globalEntityID">GlobalEntityID.</param>
        /// <returns>CitizenCommentModel list.</returns>
        List<CitizenCommentModel> GetComments(int start, int end, Guid globalEntityID, string appID);

        /// <summary>
        /// Add comment.
        /// </summary>
        /// <param name="globalEntityID">GlobalEntityID.</param>        
        /// <param name="comment">Comment.</param>
        /// <param name="appID">AppID.</param>
        /// <param name="cloudUserId">Cloud User Id.</param>
        /// <returns>CitizenCommentModel.</returns>
        CitizenCommentModel Add(Guid globalEntityID, string comment, Guid cloudUserId,string createdBy, string appID, out int userCommentCount);

        /// <summary>
        /// Get Top Comments.
        /// </summary>
        /// <param name="offSet">OffSet</param>
        /// <param name="limit">Limit</param>
        /// <param name="globalEntityID">GlobalEntityID.</param>
        /// <returns>CitizenCommentModel list.</returns>
        List<CitizenCommentModel> GetTopComments(int offSet, int limit, Guid globalEntityID);


        /// <summary>
        /// Get Comments Count
        /// </summary>
        /// <param name="globalEntityID">GlobalEntityID</param>
        /// <param name="appID">AppID</param>
        /// <returns>Comments Count</returns>
        int GetCommentsCount( Guid globalEntityID);
    }
}
