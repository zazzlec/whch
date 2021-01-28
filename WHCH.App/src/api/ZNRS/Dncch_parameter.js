

import axios from '@/libs/api.request'

export const getCh_parameterListAll = () => {
  return axios.request({
    url:  'Dncch_parameter' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getCh_parameterList = (data) => {
  return axios.request({
    url:  'Dncch_parameter' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createCh_parameter = (data) => {
  return axios.request({
    url:  'Dncch_parameter' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadCh_parameter = (data) => {
  return axios.request({
    url: 'Dncch_parameter' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editCh_parameter = (data) => {
  return axios.request({
    url: 'Dncch_parameter' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteCh_parameter = (ids) => {
  return axios.request({
    url: 'Dncch_parameter'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncch_parameter'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateCh_parameter = (data) => {
  return axios.request({
    url:  'Dncch_parameter' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

