

import axios from '@/libs/api.request'

export const getBoilerratListAll = () => {
  return axios.request({
    url:  'Dncboilerrat' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getBoilerratList = (data) => {
  return axios.request({
    url:  'Dncboilerrat' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createBoilerrat = (data) => {
  return axios.request({
    url:  'Dncboilerrat' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadBoilerrat = (data) => {
  return axios.request({
    url: 'Dncboilerrat' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editBoilerrat = (data) => {
  return axios.request({
    url: 'Dncboilerrat' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteBoilerrat = (ids) => {
  return axios.request({
    url: 'Dncboilerrat'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncboilerrat'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateBoilerrat = (data) => {
  return axios.request({
    url:  'Dncboilerrat' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

