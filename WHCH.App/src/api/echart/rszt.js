let option4days=['正常','超限报警','右切圆偏斜','左切圆偏斜','右切圆起旋\n动量不足','左切圆起旋\n动量不足',  '右切圆消旋\n动量不足', '左切圆消旋\n动量不足' ];
export const leftdata={
    tooltip: {
        trigger: 'item',
        position:'top',
        axisPointer: {            
            type: 'shadow'        
        },
        // formatter:'{b0}'
        formatter: function (params) {
            var index=parseInt(params.value[1])
            return params.name+"<br>"+option4days[index];
        }
    },
    animation: false,
    grid: {
        x: "70px",
        y: "30px",
        x2: "20px",
        y2: "100px"
    },

    xAxis: {
        type: 'category',
        splitLine: {show: false},
        data: [],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            },
            rotate: 60
        }
    },
    yAxis: {
        type: 'category',
        data: option4days,
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
    
}

export const leftdata_back={
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
    tooltip: {
        trigger: 'item',
        position:'top',
        axisPointer: {            
            type: 'shadow'        
        },
        // formatter:'{b0}'
        formatter: function (params) {
            var index=parseInt(params.value[1])
            return params.name+"<br>"+option4days[index];
        }
    },
    animation: false,
    grid: {
        x: "70px",
        y: "30px",
        x2: "20px",
        y2: "100px"
    },

    xAxis: {
        type: 'category',
        splitLine: {show: false},
        data: [],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            },
            rotate: 60
        }
    },
    yAxis: {
        type: 'category',
        data: option4days,
        splitArea: {
            show: true
        },
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        }
    },
    
    series: [{
        name: '燃烧值',
        type: 'heatmap',
        data: [],
        itemStyle: {
            emphasis: {
                shadowBlur: 10,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
        }
    }]
    
}

export const rightdata1 = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return "左侧:" + (-params[1].value.toFixed(1)) + " 右侧:" + (params[0].value.toFixed(1));
        }
    },
    grid: {
        left: '0.5%',
        right: '4%',
        bottom: '15%',
        containLabel: true
    },
    legend: {
        data: ['左焓增', '右焓增'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3efff'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                formatter: function (data) {
                    return Math.abs(data)
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    yAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"

        },
        data: ['低温过热器', '分隔屏过热器', '后屏过热器', '末级过热器', '低温再热器', '高温再热器'].reverse()
        }
    ],
    series: [
        {
            name: '右焓增',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return (params.value ).toFixed(1);
                    }
                }
            },
            data: []
        },
        {
            name: '左焓增',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    label: {
                        formatter: function (a) {
                            return a.data * (-1);
                        }
                    }
                }
            }
        }
    ]
}

export const rightdata1_back = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return "左侧:" + (-params[1].value.toFixed(1)) + " 右侧:" + (params[0].value.toFixed(1));
        }
    },
    grid: {
        left: '0.5%',
        right: '4%',
        bottom: '15%',
        containLabel: true
    },
    legend: {
        data: ['左焓增', '右焓增'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3efff'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                formatter: function (data) {
                    return Math.abs(data)
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    yAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"

        },
        data: ['低温过热器', '分隔屏过热器', '后屏过热器', '末级过热器', '低温再热器', '高温再热器'].reverse()
        }
    ],
    series: [
        {
            name: '右焓增',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return (params.value ).toFixed(1);
                    }
                }
            },
            data: []
        },
        {
            name: '左焓增',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    label: {
                        formatter: function (a) {
                            return a.data * (-1);
                        }
                    }
                }
            }
        }
    ]
}

export const rightdata2 = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return "左侧:" + (-params[1].value.toFixed(1)) + " 右侧:" + (params[0].value.toFixed(1));
        }
    },
    grid: {
        left: '0.5%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    },
    legend: {
        data: ['左侧出口汽温', '右侧出口汽温'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3efff'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                formatter: function (data) {
                    return Math.abs(data)
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    yAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"

        },
        data: ['低温过热器', '分隔屏过热器', '后屏过热器', '末级过热器', '低温再热器', '高温再热器'].reverse()
        }
    ],
    series: [
        {
            name: '右侧出口汽温',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
        },
        {
            name: '左侧出口汽温',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    label: {
                        formatter: function (a) {
                            return a.data * (-1);
                        }
                    }
                }
            }
        }
    ]
}

export const rightdata2_back = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
        formatter: function (params) {
            return "左侧:" + (-params[1].value.toFixed(1)) + " 右侧:" + (params[0].value.toFixed(1));
        }
    },
    grid: {
        left: '0.5%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    },
    legend: {
        data: ['左侧出口汽温', '右侧出口汽温'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3efff'//字体颜色
        }
    },
    xAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                formatter: function (data) {
                    return Math.abs(data)
                }
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    yAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"

        },
        data: ['低温过热器', '分隔屏过热器', '后屏过热器', '末级过热器', '低温再热器', '高温再热器'].reverse()
        }
    ],
    series: [
        {
            name: '右侧出口汽温',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
        },
        {
            name: '左侧出口汽温',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: true,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return Math.abs((params.value )).toFixed(1);
                    }
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    label: {
                        formatter: function (a) {
                            return a.data * (-1);
                        }
                    }
                }
            }
        }
    ]
}
