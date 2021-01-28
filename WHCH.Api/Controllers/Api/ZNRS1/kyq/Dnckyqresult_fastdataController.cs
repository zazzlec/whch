
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
using WHCH.Api.RequestPayload.Rbac.Kyqresult_fastdata;
using WHCH.Api.ViewModels.Rbac.Dnckyqresult_fastdata;
using System.Transactions;
using System.Collections.Generic;
using WHCH.Api.Utils;
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
    public class Dnckyqresult_fastdataController : ControllerBase
    {
        private readonly WHCHDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造control
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public Dnckyqresult_fastdataController(WHCHDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult List()
        {
            using (_dbContext)
            {
                var list = _dbContext.Dnckyqresult_fastdata.ToList();
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
        public IActionResult List(Dnckyqresult_fastdataRequestPayload payload)

        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.Dnckyqresult_fastdata.AsQueryable();
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
                if (!string.IsNullOrEmpty(payload.kyq))
                {
                    query = query.Where(x => x.DncKyq.K_Name_kw == payload.kyq);
                }
                if (payload.boilerid != -1)
                {
                    query = query.Where(x => x.DncBoilerId == payload.boilerid);
                }
                if (!string.IsNullOrEmpty(payload.d1) && !string.IsNullOrEmpty(payload.d2))
                {
                    var btime = DateTime.Parse(payload.d1);
                    var etime = DateTime.Parse(payload.d2);
                    query = query.Where(x => x.RealTime.Value >= btime && x.RealTime.Value <= etime);
                }
                if (payload.FirstSort != null)
                {
                    query = query.OrderBy(payload.FirstSort.Field, payload.FirstSort.Direct == "DESC");
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map< Dnckyqresult_fastdata, Dnckyqresult_fastdataJsonModel>);

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
        public IActionResult Create(Dnckyqresult_fastdataCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var entity = _mapper.Map< Dnckyqresult_fastdataCreateViewModel, Dnckyqresult_fastdata>(model);
                if (string.IsNullOrEmpty(model.DncBoiler_Name))
                {
                    entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == "无");
                    entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                }
                else
                {
                    entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncBoiler_Name);
                    entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                }
                if (string.IsNullOrEmpty(model.DncKyq_Name))
                {
                    entity.DncKyq = _dbContext.Dnckyq.FirstOrDefault(x => (x.K_Name_kw + "") == "无");
                    entity.DncKyq_Name = entity.DncKyq.K_Name_kw;
                }
                else
                {
                    entity.DncKyq = _dbContext.Dnckyq.FirstOrDefault(x => (x.K_Name_kw + "") == model.DncKyq_Name);
                    entity.DncKyq_Name = entity.DncKyq.K_Name_kw;
                }
                entity.Status = CommonEnum.Status.Normal;
                _dbContext.Dnckyqresult_fastdata.Add(entity);
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
                var entity = _dbContext.Dnckyqresult_fastdata.FirstOrDefault(x => x.Id ==  int.Parse(code));
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map< Dnckyqresult_fastdata, Dnckyqresult_fastdataCreateViewModel>(entity));
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
        public IActionResult Edit(Dnckyqresult_fastdataEditViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {


                var entity = _dbContext.Dnckyqresult_fastdata.FirstOrDefault(x => x.Id == model.Id);





                entity.RealTime = model.RealTime;
                entity.Remark = model.Remark;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == model.DncBoiler_Name);
                entity.DncBoiler_Name = entity.DncBoiler.K_Name_kw;
                entity.DncBoiler_Name = model.DncBoiler_Name;
                entity.Lcs_Status = model.Lcs_Status;
                entity.Kyq_Run_Dl_Val = model.Kyq_Run_Dl_Val;
                entity.Kyq_Speed_Val = model.Kyq_Speed_Val;
                entity.Mfjx_Val = model.Mfjx_Val;
                entity.Gas_O2_Out_Val = model.Gas_O2_Out_Val;
                entity.Gas_O2_In_Val = model.Gas_O2_In_Val;
                entity.Wind_Out_Radio_Val = model.Wind_Out_Radio_Val;
                entity.Gas_Press_In_Val = model.Gas_Press_In_Val;
                entity.Gas_Press_Out_Val = model.Gas_Press_Out_Val;
                entity.Wind1_Press_In_Val = model.Wind1_Press_In_Val;
                entity.Wind1_Press_Out_Val = model.Wind1_Press_Out_Val;
                entity.Wind2_Press_In_Val = model.Wind2_Press_In_Val;
                entity.Wind2_Press_Out_Val = model.Wind2_Press_Out_Val;
                entity.Res_Gas_Val = model.Res_Gas_Val;
                entity.Res_Wind1_Val = model.Res_Wind1_Val;
                entity.Res_Wind2_Val = model.Res_Wind2_Val;
                entity.Chq_Press_Hot_Val = model.Chq_Press_Hot_Val;
                entity.Chq_Press_Cold_Val = model.Chq_Press_Cold_Val;
                entity.Chq_Temp_Hot_Val = model.Chq_Temp_Hot_Val;
                entity.Chq_Temp_Cold_Val = model.Chq_Temp_Cold_Val;
                entity.Gysb_Press_Val = model.Gysb_Press_Val;
                entity.DncKyq = _dbContext.Dnckyq.FirstOrDefault(x => x.K_Name_kw == model.DncKyq_Name);
                entity.DncKyq_Name = entity.DncKyq.K_Name_kw;
                entity.DncKyq_Name = model.DncKyq_Name;
                entity.ReductionBoxTemperature = model.ReductionBoxTemperature;
                entity.EnvironmentTemperature = model.EnvironmentTemperature;
                entity.LcsRunMode = model.LcsRunMode;
                entity.FanShapedPlateP1 = model.FanShapedPlateP1;
                entity.FanShapedPlateP2 = model.FanShapedPlateP2;
                entity.FanShapedPlateP3 = model.FanShapedPlateP3;
                entity.FanShapedPlateS1 = model.FanShapedPlateS1;
                entity.FanShapedPlateS2 = model.FanShapedPlateS2;
                entity.FanShapedPlateS3 = model.FanShapedPlateS3;
                entity.LiftingDeviceS1 = model.LiftingDeviceS1;
                entity.LiftingDeviceS2 = model.LiftingDeviceS2;
                entity.LiftingDeviceS3 = model.LiftingDeviceS3;

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
                if (ToolService.DbType.Equals("mysql")){
                    var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dnckyqresult_fastdata SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dnckyqresult_fastdata SET IsDeleted=@IsDeleted WHERE id IN ({0})", parameterNames);
                    parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }
                
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
                if (ToolService.DbType.Equals("mysql")){
                    var parameters = ids.Split(",").Select((id, index) => new MySqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dnckyqresult_fastdata SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new MySqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }else{
                    var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                    var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                    var sql = string.Format("UPDATE Dnckyqresult_fastdata SET Status=@Status WHERE id IN ({0})", parameterNames);
                    parameters.Add(new SqlParameter("@Status", (int)status));
                    _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                    var response = ResponseModelFactory.CreateInstance;
                    return response;
                }
                
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
                        KeyValuePair<string, List< Dnckyqresult_fastdataCreateViewModel>> res = ValidateJson.Validation< Dnckyqresult_fastdataCreateViewModel>(fsts);

                        if (res.Key.Equals("ok"))
                        {
                            List< Dnckyqresult_fastdataCreateViewModel> arr = res.Value;
                            foreach ( Dnckyqresult_fastdataCreateViewModel item in arr)
                            {

      
                                
                                
                                
                                
                                
                                
                                var entity = _mapper.Map< Dnckyqresult_fastdataCreateViewModel, Dnckyqresult_fastdata>(item);
                                
                                entity.DncBoiler = _dbContext.Dncboiler.FirstOrDefault(x => x.K_Name_kw == item.DncBoiler_Name);
                                entity.DncKyq = _dbContext.Dnckyq.FirstOrDefault(x => x.K_Name_kw == item.DncKyq_Name);
                                
                                entity.Status = CommonEnum.Status.Normal;
                                _dbContext.Dnckyqresult_fastdata.Add(entity);
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









