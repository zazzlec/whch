

import axios from '@/libs/api.request'

export const getChpoint_wrlListAll = () => {
  return axios.request({
    url:  'Dncchpoint_wrl' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChpoint_wrlList = (data) => {
  return axios.request({
    url:  'Dncchpoint_wrl' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChpoint_wrl = (data) => {
  return axios.request({
    url:  'Dncchpoint_wrl' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChpoint_wrl = (data) => {
  return axios.request({
    url: 'Dncchpoint_wrl' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChpoint_wrl = (data) => {
  return axios.request({
    url: 'Dncchpoint_wrl' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChpoint_wrl = (ids) => {
  return axios.request({
    url: 'Dncchpoint_wrl'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchpoint_wrl'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChpoint_wrl = (data) => {
  return axios.request({
    url:  'Dncchpoint_wrl' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

