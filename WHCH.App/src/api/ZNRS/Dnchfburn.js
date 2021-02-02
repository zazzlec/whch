

import axios from '@/libs/api.request'

export const getHfburnListAll = () => {
  return axios.request({
    url:  'Dnchfburn' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHfburnList = (data) => {
  return axios.request({
    url:  'Dnchfburn' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHfburn = (data) => {
  return axios.request({
    url:  'Dnchfburn' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHfburn = (data) => {
  return axios.request({
    url: 'Dnchfburn' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHfburn = (data) => {
  return axios.request({
    url: 'Dnchfburn' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHfburn = (ids) => {
  return axios.request({
    url: 'Dnchfburn'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchfburn'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHfburn = (data) => {
  return axios.request({
    url:  'Dnchfburn' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

