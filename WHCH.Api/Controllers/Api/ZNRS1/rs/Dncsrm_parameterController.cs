
using System;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using WHCH.Api.Entities;
using WHCH.Api.Entities.Enums;
using WHCH.Api.Extensions;
using WHCH.Api.Extensions.AuthContext;
using WHCH.Api.Extensions.CustomException;
using WHCH.Api.Extensions.DataAccess;
using WHCH.Api.Models.Response;
using WHCH.Api.RequestPayload.Rbac.Role;
using WHCH.Api.Utils;
using WHCH.Api.ViewModels.Rbac.DncRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WHCH.Api.RequestPayload.Rbac.Srm_parameter;
using WHCH.Api.ViewModels.Rbac.Dncsrm_parameter;
using System.Transactions;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WHCH.Api.Controllers.Api.WHCH1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/WHCH1/[controller]/[action]")]
    [ApiController]
    //[CustomAuthorize]
    public class Dncsrm_parameterController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dncsrm_parameterController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dncsrm_parameter.ToList();
                list = list.FindAll(x => x.IsDeleted != CommonEnum.IsDeleted.Yes );
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(list);
                return Ok(response);
            }
        }
        /// <summary>
        /// 查询请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(Dncsrm_parameterRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dncsrm_parameter.AsQueryable();
                //模糊查询
                
                //是否删除，是否启用
                if (payload.IsDeleted > CommonEnum.IsDeleted.All)
                {
                    query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                }
                if (payload.Status > CommonEnum.Status.All)
                {
                    query = query.Where(x => x.Status == payload.Status);
                }
                if (payload.boilerid != -1)
                {
                    query = query.Where(x => x.DncBoilerId == payload.boilerid);
                }
         
                if (payload.FirstSort != null)
                {
                    query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map< Dncsrm_parameter, Dncsrm_parameterJsonModel>);

                response.SetData(data, totalCount);
                return Ok(response);
            }
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(Dncsrm_parameterCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< Dncsrm_parameterCreateViewModel, Dncsrm_parameter>(model);
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dncsrm_parameter.Add(entity);
                _dbContext.SaveChanges();

                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 编辑页获取实体
        /// </summary>
        /// <param name="code">惟一编码</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(string code)
        {
            using (_dbContext)
            {
                var entity = _dbContext.Dncsrm_parameter.FirstOrDefault(x => (x.Id+"") == code);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dncsrm_parameter, Dncsrm_parameterCreateViewModel>(entity));
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存编辑后的信息
        /// </summary>
        /// <param name="model">视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(Dncsrm_parameterEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dncsrm_parameter.FirstOrDefault(x => x.Id == model.Id);





                entity.Zrqll_design = model.Zrqll_design;
                entity.Hz_a1 = model.Hz_a1;
                entity.Hz_a2 = model.Hz_a2;
                entity.Hz_a3 = model.Hz_a3;
                entity.Hz_a4 = model.Hz_a4;
                entity.Hz_a5 = model.Hz_a5;
                entity.Hz_a6 = model.Hz_a6;
                entity.Hz_a7 = model.Hz_a7;
                entity.Hz_a8 = model.Hz_a8;
                entity.Zrq_jws_mh_xs = model.Zrq_jws_mh_xs;
                entity.Gz_out_temp_ed = model.Gz_out_temp_ed;
                entity.Gz_out_temp_high = model.Gz_out_temp_high;
                entity.Gz_out_temp_low = model.Gz_out_temp_low;
                entity.Gz_out_temp_mh_xs = model.Gz_out_temp_mh_xs;
                entity.Mg_out_temp_ed = model.Mg_out_temp_ed;
                entity.Mg_out_temp_high = model.Mg_out_temp_high;
                entity.Mg_out_temp_low = model.Mg_out_temp_low;
                entity.Mg_out_temp_mh_xs = model.Mg_out_temp_mh_xs;
                entity.Fh_zone = model.Fh_zone;
                entity.O2_high_zone = model.O2_high_zone;
                entity.O2_low_zone = model.O2_low_zone;
                entity.Nox_high_zone = model.Nox_high_zone;
                entity.Nox_low_zone = model.Nox_low_zone;
                entity.Zwxs_fh_zone = model.Zwxs_fh_zone;
                entity.Fgp_design_hz_zone = model.Fgp_design_hz_zone;
                entity.Fgp_design_zwxs = model.Fgp_design_zwxs;
                entity.Fgp_zwxs_high = model.Fgp_zwxs_high;
                entity.Fgp_zwxs_low = model.Fgp_zwxs_low;
                entity.Hp_design_hz_zone = model.Hp_design_hz_zone;
                entity.Hp_design_zwxs = model.Hp_design_zwxs;
                entity.Hp_zwxs_high = model.Hp_zwxs_high;
                entity.Hp_zwxs_low = model.Hp_zwxs_low;
                entity.Mg_design_hz_zone = model.Mg_design_hz_zone;
                entity.Mg_design_zwxs = model.Mg_design_zwxs;
                entity.Mg_zwxs_high = model.Mg_zwxs_high;
                entity.Mg_zwxs_low = model.Mg_zwxs_low;
                entity.Dz_design_hz_zone = model.Dz_design_hz_zone;
                entity.Dz_design_zwxs = model.Dz_design_zwxs;
                entity.Dz_zwxs_high = model.Dz_zwxs_high;
                entity.Dz_zwxs_low = model.Dz_zwxs_low;
                entity.Gz_design_hz_zone = model.Gz_design_hz_zone;
                entity.Gz_design_zwxs = model.Gz_design_zwxs;
                entity.Gz_zwxs_high = model.Gz_zwxs_high;
                entity.Gz_zwxs_low = model.Gz_zwxs_low;
                entity.Dg_design_hz_zone = model.Dg_design_hz_zone;
                entity.Dg_design_zwxs = model.Dg_design_zwxs;
                entity.Dg_zwxs_high = model.Dg_zwxs_high;
                entity.Dg_zwxs_low = model.Dg_zwxs_low;
                entity.Agp_basic_percent = model.Agp_basic_percent;
                entity.Grq_jws_design_1 = model.Grq_jws_design_1;
                entity.Grq_jws_design_2 = model.Grq_jws_design_2;
                entity.Grq_jws_design_3 = model.Grq_jws_design_3;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;

                _dbContext.SaveChanges();
                return Ok(response);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {
            var response = ResponseModelFactory.CreateInstance;

            response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
            return Ok(response);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(CommonEnum.IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE Dncsrm_parameter SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
            return Ok(response);
        }
        
        
        /// <summary>
        /// 批量更新状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="ids">ID字符串,多个以逗号隔开</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE Dncsrm_parameter SET Status=@Status WHERE id IN ({0})", parameterNames);
                parameters.Add(new MySqlParameter("@Status", (int)status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            switch (command)
            {
                case "delete":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
                    break;
                case "recover":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
                    break;
                case "forbidden":
                    response = UpdateStatus(UserStatus.Forbidden, ids);
                    break;
                case "normal":
                    response = UpdateStatus(UserStatus.Normal, ids);
                    break;
                default:
                    break;
            }
            return Ok(response);
        }


        
        

        /// <summary>
        /// 批量创建
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult BatchCreate(string fsts)
        {
            var response = ResponseModelFactory.CreateInstance;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (_dbContext)
                    {
                        KeyValuePair<string, List< Dncsrm_parameterCreateViewModel>> res = ValidateJson.Validation< Dncsrm_parameterCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dncsrm_parameterCreateViewModel> arr = res.Value;
                            foreach ( Dncsrm_parameterCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< Dncsrm_parameterCreateViewModel, Dncsrm_parameter>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dncsrm_parameter.Add(entity);
                            }
                        }
                        else
                        {
                            response.SetFailed(res.Key + " 数据格式有误.");
                            return Ok(response);
                        }
                        _dbContext.SaveChanges();
                    }
                    // 如果所有的操作都执行成功，则Complete()会被调用来提交事务
                    // 如果发生异常，则不会调用它并回滚事务
                    scope.Complete();
                }
                response.SetSuccess();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetFailed(ex.Message);
                return Ok(response);
            }
        }
        

    }
}









