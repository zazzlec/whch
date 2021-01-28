

import axios from '@/libs/api.request'

export const getHzpoint_typeListAll = () => {
  return axios.request({
    url:  'Dnchzpoint_type' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHzpoint_typeList = (data) => {
  return axios.request({
    url:  'Dnchzpoint_type' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHzpoint_type = (data) => {
  return axios.request({
    url:  'Dnchzpoint_type' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHzpoint_type = (data) => {
  return axios.request({
    url: 'Dnchzpoint_type' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHzpoint_type = (data) => {
  return axios.request({
    url: 'Dnchzpoint_type' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHzpoint_type = (ids) => {
  return axios.request({
    url: 'Dnchzpoint_type'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchzpoint_type'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHzpoint_type = (data) => {
  return axios.request({
    url:  'Dnchzpoint_type' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

