

import axios from '@/libs/api.request'

export const getWindListAll = () => {
  return axios.request({
    url:  'Dncwind' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getWindList = (data) => {
  return axios.request({
    url:  'Dncwind' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createWind = (data) => {
  return axios.request({
    url:  'Dncwind' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadWind = (data) => {
  return axios.request({
    url: 'Dncwind' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editWind = (data) => {
  return axios.request({
    url: 'Dncwind' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteWind = (ids) => {
  return axios.request({
    url: 'Dncwind'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncwind'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateWind = (data) => {
  return axios.request({
    url:  'Dncwind' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

