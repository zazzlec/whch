

import axios from '@/libs/api.request'

export const getBoilerstatusListAll = () => {
  return axios.request({
    url:  'Dncboilerstatus' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getBoilerstatusList = (data) => {
  return axios.request({
    url:  'Dncboilerstatus' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createBoilerstatus = (data) => {
  return axios.request({
    url:  'Dncboilerstatus' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadBoilerstatus = (data) => {
  return axios.request({
    url: 'Dncboilerstatus' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editBoilerstatus = (data) => {
  return axios.request({
    url: 'Dncboilerstatus' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteBoilerstatus = (ids) => {
  return axios.request({
    url: 'Dncboilerstatus'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncboilerstatus'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateBoilerstatus = (data) => {
  return axios.request({
    url:  'Dncboilerstatus' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

