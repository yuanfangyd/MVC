//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.Models.Sys;
using Apps.MIS.IBLL;
using Apps.MIS.IDAL;
using Microsoft.Practices.Unity;
using Apps.Common;
using Apps.BLL.Core;

namespace Apps.MIS.BLL
{
	public class Virtual_MIS_ArticleBLL 
	{
		[Dependency]
        public IMIS_ArticleRepository m_Rep { get; set; }

		public DBContainer db = new DBContainer();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public virtual List<MIS_ArticleModel> GetList(ref GridPager pager,string queryStr)
        {

            IQueryable<MIS_Article> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
										a => (a.Id!=null&&a.Id.Contains(queryStr))
															
														||  (a.CategoryId!=null&&a.CategoryId.Contains(queryStr))
														||  (a.Title!=null&&a.Title.Contains(queryStr))
														||  (a.ImgUrl!=null&&a.ImgUrl.Contains(queryStr))
														||  (a.BodyContent!=null&&a.BodyContent.Contains(queryStr))
														
														
														
														||  (a.Checker!=null&&a.Checker.Contains(queryStr))
														
														||  (a.Creater!=null&&a.Creater.Contains(queryStr))
														
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            List<MIS_ArticleModel> modelList = (from r in queryData
                                              select new MIS_ArticleModel
                                              {
                                                 													 Id = r.Id,
                                                  													 ChannelId = r.ChannelId,
                                                  													 CategoryId = r.CategoryId,
                                                  													 Title = r.Title,
                                                  													 ImgUrl = r.ImgUrl,
                                                  													 BodyContent = r.BodyContent,
                                                  													 Sort = r.Sort,
                                                  													 Click = r.Click,
                                                  													 CheckFlag = r.CheckFlag,
                                                  													 Checker = r.Checker,
                                                  													 CheckDateTime = r.CheckDateTime,
                                                  													 Creater = r.Creater,
                                                  													 CreateTime = r.CreateTime,
                                                  
                                              }).ToList();
            return modelList;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Create(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article();
                					entity.Id = model.Id;
                    					entity.ChannelId = model.ChannelId;
                    					entity.CategoryId = model.CategoryId;
                    					entity.Title = model.Title;
                    					entity.ImgUrl = model.ImgUrl;
                    					entity.BodyContent = model.BodyContent;
                    					entity.Sort = model.Sort;
                    					entity.Click = model.Click;
                    					entity.CheckFlag = model.CheckFlag;
                    					entity.Checker = model.Checker;
                    					entity.CheckDateTime = model.CheckDateTime;
                    					entity.Creater = model.Creater;
                    					entity.CreateTime = model.CreateTime;
                    
                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.add("插入失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.DeleteFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public virtual bool Edit(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.add(Suggestion.Disable);
                    return false;
                }
                					entity.Id = model.Id;
                    					entity.ChannelId = model.ChannelId;
                    					entity.CategoryId = model.CategoryId;
                    					entity.Title = model.Title;
                    					entity.ImgUrl = model.ImgUrl;
                    					entity.BodyContent = model.BodyContent;
                    					entity.Sort = model.Sort;
                    					entity.Click = model.Click;
                    					entity.CheckFlag = model.CheckFlag;
                    					entity.Checker = model.Checker;
                    					entity.CheckDateTime = model.CheckDateTime;
                    					entity.Creater = model.Creater;
                    					entity.CreateTime = model.CreateTime;
                    


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.add(Suggestion.EditFail);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.add(ex.Message);
                ExceptionHandler.WriteException(ex);
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public virtual bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public virtual MIS_ArticleModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article entity = m_Rep.GetById(id);
                MIS_ArticleModel model = new MIS_ArticleModel();
                					 model.Id = entity.Id;
                    					 model.ChannelId = entity.ChannelId;
                    					 model.CategoryId = entity.CategoryId;
                    					 model.Title = entity.Title;
                    					 model.ImgUrl = entity.ImgUrl;
                    					 model.BodyContent = entity.BodyContent;
                    					 model.Sort = entity.Sort;
                    					 model.Click = entity.Click;
                    					 model.CheckFlag = entity.CheckFlag;
                    					 model.Checker = entity.Checker;
                    					 model.CheckDateTime = entity.CheckDateTime;
                    					 model.Creater = entity.Creater;
                    					 model.CreateTime = entity.CreateTime;
                    
                return model;
            }
            else
            {
                return null;
            }
        }
	}
}
