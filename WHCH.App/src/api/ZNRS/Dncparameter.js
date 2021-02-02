

import axios from '@/libs/api.request'

export const getParameterListAll = () => {
  return axios.request({
    url:  'Dncparameter' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getParameterList = (data) => {
  return axios.request({
    url:  'Dncparameter' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createParameter = (data) => {
  return axios.request({
    url:  'Dncparameter' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadParameter = (data) => {
  return axios.request({
    url: 'Dncparameter' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editParameter = (data) => {
  return axios.request({
    url: 'Dncparameter' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteParameter = (ids) => {
  return axios.request({
    url: 'Dncparameter'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncparameter'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateParameter = (data) => {
  return axios.request({
    url:  'Dncparameter' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

