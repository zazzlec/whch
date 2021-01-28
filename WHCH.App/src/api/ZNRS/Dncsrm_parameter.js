

import axios from '@/libs/api.request'

export const getSrm_parameterListAll = () => {
  return axios.request({
    url:  'Dncsrm_parameter' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getSrm_parameterList = (data) => {
  return axios.request({
    url:  'Dncsrm_parameter' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createSrm_parameter = (data) => {
  return axios.request({
    url:  'Dncsrm_parameter' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadSrm_parameter = (data) => {
  return axios.request({
    url: 'Dncsrm_parameter' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editSrm_parameter = (data) => {
  return axios.request({
    url: 'Dncsrm_parameter' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteSrm_parameter = (ids) => {
  return axios.request({
    url: 'Dncsrm_parameter'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncsrm_parameter'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateSrm_parameter = (data) => {
  return axios.request({
    url:  'Dncsrm_parameter' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

