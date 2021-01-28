

import axios from '@/libs/api.request'

export const getGwfspointresetListAll = () => {
  return axios.request({
    url:  'Dncgwfspointreset' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getGwfspointresetList = (data) => {
  return axios.request({
    url:  'Dncgwfspointreset' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createGwfspointreset = (data) => {
  return axios.request({
    url:  'Dncgwfspointreset' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadGwfspointreset = (data) => {
  return axios.request({
    url: 'Dncgwfspointreset' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editGwfspointreset = (data) => {
  return axios.request({
    url: 'Dncgwfspointreset' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteGwfspointreset = (ids) => {
  return axios.request({
    url: 'Dncgwfspointreset'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncgwfspointreset'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateGwfspointreset = (data) => {
  return axios.request({
    url:  'Dncgwfspointreset' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

