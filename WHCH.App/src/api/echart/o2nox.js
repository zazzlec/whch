export const o2x1={
    title: {
        // text: 'NOX动态',
        //                subtext: '纯属虚构'
    },
   
    grid: {
        y: 80
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#283b56'
            }
        },
        formatter: function (params) {
            return "上限值:" + (params[0].value) + "<br>O₂平均值:" +(params[1].value)+ "<br>下限值:" +(params[2].value)+ "<br>负荷:" +(params[3].value);
        }
    },
    legend: {
        data: [ 'O₂平均值', '负荷'],


        x: "center",
        y: "15px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },

            data: [],
        }
    ],
    yAxis: [
        {
            name:'O₂',
            type: 'value',
            scale: true,
            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        },
        {
            name:'负荷',
            type: 'value',
            scale: true,
            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }

    ],


    series: [
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#9DE49d',
                // origin:'auto'

            },
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                           
                        }
                    }
            },
        },
        {
            name: 'O₂平均值',
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            seriesLayoutBy: 'row',
            data: [],
        },
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#C8DDC8',
                origin:'start',
                opacity:1
            },
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                          
                        }
                    }
            },
        },
        {
            name: '负荷',
            type: 'line',
            smooth: true,
            yAxisIndex:1,
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 1,
                            type: 'solid',
                           
                        }
                    }
            },
            // seriesLayoutBy: 'row',
            data: []
        }
    ]
}



export const o2x1_back={
    dataZoom:[{
        type: 'inside',
        start: 90,
        end: 100
    }, {
        bottom:"0%", 
        handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
        handleSize: '80%',
        handleStyle: {
            color: '#fff',
            shadowBlur: 3,
            shadowColor: '#11111',
            shadowOffsetX: 2,
            shadowOffsetY: 2
        }
    }],
    toolbox: {
        feature: {
            saveAsImage: {}
        }
    },
    
    title: {
        // text: 'NOX动态',
        //                subtext: '纯属虚构'
    },
   
    grid: {
        y: 80
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#283b56'
            }
        },
        formatter: function (params) {
            return "上限值:" + (params[0].value) + "<br>O₂平均值:" +(params[1].value)+ "<br>下限值:" +(params[2].value)+ "<br>负荷:" +(params[3].value);
        }
    },
    legend: {
        data: [ 'O₂平均值', '负荷'],


        x: "center",
        y: "15px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },

            data: [],
        }
    ],
    yAxis: [
        {
            name:'O₂',
            type: 'value',
            scale: true,
            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        },
        {
            name:'负荷',
            type: 'value',
            scale: true,
            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }

    ],


    series: [
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#9DE49d',
                // origin:'auto'

            },
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                           
                        }
                    }
            },
        },
        {
            name: 'O₂平均值',
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            seriesLayoutBy: 'row',
            data: [],
        },
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#C8DDC8',
                origin:'start',
                opacity:1
            },
            type: 'line',
            smooth: true,
            yAxisIndex:0,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                          
                        }
                    }
            },
        },
        {
            name: '负荷',
            type: 'line',
            smooth: true,
            yAxisIndex:1,
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 1,
                            type: 'solid',
                           
                        }
                    }
            },
            // seriesLayoutBy: 'row',
            data: []
        }
    ]
}



export const o2x2 = {
    title: {
        // text: 'NOX动态',
        //                subtext: '纯属虚构'
    },
    grid: {
        y: 80
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#283b56'
            }
        },
        formatter: function (params) {
            return "上限值:" + (params[0].value) + "<br>NOx平均值:" +(params[1].value)+ "<br>下限值:" +(params[2].value)+ "<br>负荷:" +(params[3].value);
        }
    },
    legend: {
        data: [ 'NOx平均值','负荷'],


        x: "center",
        y: "15px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45

            },

            data:  [],
        }
    ],
    yAxis: [
        {
            name:'NOx',
            type: 'value',
            scale: true,

            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        },
        {
            name:'负荷',
            type: 'value',
            scale: true,

            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }

    ],
    series: [
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#9DE49d'
            },
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                         
                        }
                    }
            },


        },
        {
            name: 'NOx平均值',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            
        },
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#C8DDC8',
                opacity:1
            },
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                         
                        }
                    }
            },
        },
        {
            name: '负荷',
            type: 'line',
            smooth: true,
            yAxisIndex:1,
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 1,
                            type: 'solid',
                         
                        }
                    }
            },
            // seriesLayoutBy: 'row',
            data: []
        }
    ]
}

export const o2x2_back = {
    dataZoom:[{
        type: 'inside',
        start: 90,
        end: 100
    }, {
        bottom:"0%", 
        handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
        handleSize: '80%',
        handleStyle: {
            color: '#fff',
            shadowBlur: 3,
            shadowColor: '#11111',
            shadowOffsetX: 2,
            shadowOffsetY: 2
        }
    }],
    toolbox: {
        feature: {
            saveAsImage: {}
        }
    },
    
    title: {
        // text: 'NOX动态',
        //                subtext: '纯属虚构'
    },
    grid: {
        y: 80
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#283b56'
            }
        },
        formatter: function (params) {
            return "上限值:" + (params[0].value) + "<br>NOx平均值:" +(params[1].value)+ "<br>下限值:" +(params[2].value)+ "<br>负荷:" +(params[3].value);
        }
    },
    legend: {
        data: [ 'NOx平均值','负荷'],


        x: "center",
        y: "15px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45

            },

            data:  [],
        }
    ],
    yAxis: [
        {
            name:'NOx',
            type: 'value',
            scale: true,

            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        },
        {
            name:'负荷',
            type: 'value',
            scale: true,

            boundaryGap: [0.2, 0.2],

            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }

    ],
    series: [
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#9DE49d'
            },
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                         
                        }
                    }
            },


        },
        {
            name: 'NOx平均值',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            
        },
        {
            name: '',
            symbol:'none',
            areaStyle: {
                color:'#C8DDC8',
                opacity:1
            },
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: [],
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 0,
                            type: 'dotted',
                         
                        }
                    }
            },
        },
        {
            name: '负荷',
            type: 'line',
            smooth: true,
            yAxisIndex:1,
            itemStyle: {
                normal:
                    {
                        lineStyle: {
                            width: 1,
                            type: 'solid',
                         
                        }
                    }
            },
            // seriesLayoutBy: 'row',
            data: []
        }
    ]
}

