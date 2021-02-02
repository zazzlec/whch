

import axios from '@/libs/api.request'

export const getPointkksListAll = () => {
  return axios.request({
    url:  'Dncpointkks' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getPointkksList = (data) => {
  return axios.request({
    url:  'Dncpointkks' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createPointkks = (data) => {
  return axios.request({
    url:  'Dncpointkks' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadPointkks = (data) => {
  return axios.request({
    url: 'Dncpointkks' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editPointkks = (data) => {
  return axios.request({
    url: 'Dncpointkks' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deletePointkks = (ids) => {
  return axios.request({
    url: 'Dncpointkks'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncpointkks'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreatePointkks = (data) => {
  return axios.request({
    url:  'Dncpointkks' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

