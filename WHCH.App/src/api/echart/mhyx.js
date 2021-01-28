export const mhyx_1 = {
    legend: {
        data: ['所有因素对煤耗的影响程度'],
        x: "center",
        y: "25px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    tooltip: {
        trigger: 'axis',
        showContent: true
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            data:  [],
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: {
        gridIndex: 0,

        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        }
    },
    
    series: [
        {
            name: '所有因素对煤耗的影响程度',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data:[],
        }
    ]
}

export const mhyx_1_back = {
    toolbox: {
        feature: {
            saveAsImage: {}
        }
    },
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
    legend: {
        data: ['所有因素对煤耗的影响程度'],
        x: "center",
        y: "25px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    tooltip: {
        trigger: 'axis',
        showContent: true
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            data:  [],
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: {
        gridIndex: 0,

        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        }
    },
    
    series: [
        {
            name: '所有因素对煤耗的影响程度',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data:[],
        }
    ]
}

export const mhyx_2={
    legend: {
        data: ['再热减温水量', '再热蒸汽温度', '过热蒸汽温度'],
        x: "center",
        y: "25px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    tooltip: {
        trigger: 'axis',
        showContent: true
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            data: [],
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: {
        gridIndex: 0,

        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        }
    },
    
    series: [
        {
            name: '再热减温水量',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: []
        },
        {
            name: '再热蒸汽温度',
            type: 'line',
            smooth: true,
            seriesLayoutBy: 'row',
            data: []
        },
        {
            name: '过热蒸汽温度',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: []
        }
    ] 
}

export const mhyx_2_back={
    
    toolbox: {
        feature: {
            saveAsImage: {}
        }
    },
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
    legend: {
        data: ['再热减温水量', '再热蒸汽温度', '过热蒸汽温度'],
        x: "center",
        y: "25px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    tooltip: {
        trigger: 'axis',
        showContent: true
    },

    xAxis: [
        {
            type: 'category',
            boundaryGap: true,
            data: [],
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            }
        }
    ],
    yAxis: {
        gridIndex: 0,

        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        }
    },
    
    series: [
        {
            name: '再热减温水量',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: []
        },
        {
            name: '再热蒸汽温度',
            type: 'line',
            smooth: true,
            seriesLayoutBy: 'row',
            data: []
        },
        {
            name: '过热蒸汽温度',
            type: 'line',
            smooth: true,
            // seriesLayoutBy: 'row',
            data: []
        }
    ] 
}

