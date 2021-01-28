

import axios from '@/libs/api.request'

export const getGwfs_parameterListAll = () => {
  return axios.request({
    url:  'Dncgwfs_parameter' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getGwfs_parameterList = (data) => {
  return axios.request({
    url:  'Dncgwfs_parameter' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createGwfs_parameter = (data) => {
  return axios.request({
    url:  'Dncgwfs_parameter' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadGwfs_parameter = (data) => {
  return axios.request({
    url: 'Dncgwfs_parameter' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editGwfs_parameter = (data) => {
  return axios.request({
    url: 'Dncgwfs_parameter' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteGwfs_parameter = (ids) => {
  return axios.request({
    url: 'Dncgwfs_parameter'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncgwfs_parameter'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateGwfs_parameter = (data) => {
  return axios.request({
    url:  'Dncgwfs_parameter' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

