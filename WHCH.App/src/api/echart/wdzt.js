export const leftdata_2 = {
    color:['red','green','','','blue'],
        legend: {
            data: ['平均值', '额定值','负荷'],
            
            x: "center",
            y: "25px",

            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
           
        },
        tooltip: {
            trigger: 'axis',
            showContent: true,
            formatter: function (params) {               

                return "上限值：" + (params[2].value) + "<br>平均值:" + (params[0].value)+ "<br>下限值:" + (params[3].value)+ "<br>额定值:" + (params[1].value);
            },
        },

        xAxis: {
            type: 'category',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },
            data: [],
        },
        yAxis: [{
            name:"出口温度",
            gridIndex: 0,  
                      
                   
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true
        },
        {
        name:"负荷",
        gridIndex:0,  
                      
                   
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        },
        scale:true
		},
		],
        series: [
            {
                name: '平均值',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'red'
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '额定值',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'green'


                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '',
                symbol:'none',
                areaStyle: {
                    color:'#9DE49d'
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',

                            }
                        }
                },
                data: []
            },
            {
                name: '',
                symbol:'none',
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',

                            }
                        }
                },
                data: []
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
                                color:'blue'
                             
                            }
                        }
                },
                // seriesLayoutBy: 'row',
                data: []
            }
        ]
}

export const leftdata_2_back = {
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
    color:['red','green','','','blue'],
        legend: {
            data: ['平均值', '额定值','负荷'],
            
            x: "center",
            y: "25px",

            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
           
        },
        tooltip: {
            trigger: 'axis',
            showContent: true,
            formatter: function (params) {               

                return "上限值：" + (params[2].value) + "<br>平均值:" + (params[0].value)+ "<br>下限值:" + (params[3].value)+ "<br>额定值:" + (params[1].value);
            },
        },

        xAxis: {
            type: 'category',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },
            data: [],
        },
        yAxis: [{
            name:"出口温度",
            gridIndex: 0,  
                      
                   
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true
        },
        {
        name:"负荷",
        gridIndex:0,  
                      
                   
        axisLabel: {
            show: true,
            textStyle: {
                color: '#3e3e3e'
            }
        },
        splitLine: {
            show: false
        },
        scale:true
		},
		],
        series: [
            {
                name: '平均值',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'red'
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '额定值',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'green'


                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '',
                symbol:'none',
                areaStyle: {
                    color:'#9DE49d'
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',

                            }
                        }
                },
                data: []
            },
            {
                name: '',
                symbol:'none',
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: false,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',

                            }
                        }
                },
                data: []
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
                                color:'blue'
                             
                            }
                        }
                },
                // seriesLayoutBy: 'row',
                data: []
            }
        ]
}

export const leftdata_2_2 ={
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
      
    },
    legend: {
        data: ['高温再热器左右温度偏差'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    yAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
           
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    xAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"
                rotate: 45

            },
            data: [],
        }
    ],
    series: [
        {
            name: '高温再热器左右温度偏差',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: false,
                    position: 'top',
                    color: "#3e3e3e",
                   
                    
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    //每根柱子颜色设置
                    color: []
                }
            }
        }
      
    ]
}

export const leftdata_2_2_back ={
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
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
      
    },
    legend: {
        data: ['高温再热器左右温度偏差'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    yAxis: [
        {
            type: 'value',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
           
            },
            splitLine: {
                show: false  //去掉网格线
            }

        }
    ],
    xAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"
                rotate: 45

            },
            data: [],
        }
    ],
    series: [
        {
            name: '高温再热器左右温度偏差',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: false,
                    position: 'top',
                    color: "#3e3e3e",
                   
                    
                }
            },
            data: [],
            itemStyle: {
                normal: {
                    //每根柱子颜色设置
                    color: []
                }
            }
        }
      
    ]
}

export const rightdata_2 = {
    color:['red','green','','','blue'],
        legend: {
            
            data: ['平均值', '额定值','负荷'],
            x: "center",
            y: "25px",

            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
        },
        tooltip: {
            trigger: 'axis',
            showContent: true,
            formatter: function (params) {               
                return "上限值：" + (params[2].value) + "<br>平均值:" + (params[0].value)+ "<br>下限值:" + (params[3].value)+ "<br>额定值:" + (params[1].value);
            },
        },

        xAxis: {
            type: 'category',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },
            data: [],
        },
        yAxis:[{
            name:"出口温度",
            gridIndex: 0,
             
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true
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

        }],
        
        series: [
            {
                name: '平均值',
                type: 'line',
                smooth: true,
                yAxisIndex:0,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'red'

          

                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '额定值',
                type: 'line',
                yAxisIndex:0,
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'green'



                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '',
                symbol:'none',
                yAxisIndex:0,
                areaStyle: {
                    color:'#9DE49d'
                },
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                      
                        }
                        }
                },
                data: []
            },
            {
                name: '',
                symbol:'none',
                yAxisIndex:0,
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
    
                            }
                        }
                },
                data: []
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
                                color:'blue'
                             
                            }
                        }
                },
                // seriesLayoutBy: 'row',
                data: []
            }
        ]
}

export const rightdata_2_back = {
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
    color:['red','green','','','blue'],
        legend: {
            
            data: ['平均值', '额定值','负荷'],
            x: "center",
            y: "25px",

            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            }
        },
        tooltip: {
            trigger: 'axis',
            showContent: true,
            formatter: function (params) {               
                return "上限值：" + (params[2].value) + "<br>平均值:" + (params[0].value)+ "<br>下限值:" + (params[3].value)+ "<br>额定值:" + (params[1].value);
            },
        },

        xAxis: {
            type: 'category',
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                rotate: 45
            },
            data: [],
        },
        yAxis:[{
            name:"出口温度",
            gridIndex: 0,
             
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                }
            },
            splitLine: {
                show: false
            },
            scale:true
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

        }],
        
        series: [
            {
                name: '平均值',
                type: 'line',
                smooth: true,
                yAxisIndex:0,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'red'

          

                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '额定值',
                type: 'line',
                yAxisIndex:0,
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:'green'



                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '',
                symbol:'none',
                yAxisIndex:0,
                areaStyle: {
                    color:'#9DE49d'
                },
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
                      
                        }
                        }
                },
                data: []
            },
            {
                name: '',
                symbol:'none',
                yAxisIndex:0,
                areaStyle: {
                    color:'#C8DDC8',
                    opacity:1
                },
                type: 'line',
                smooth: true,
                seriesLayoutBy: 'row',
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 0,
                                type: 'dotted',
    
                            }
                        }
                },
                data: []
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
                                color:'blue'
                             
                            }
                        }
                },
                // seriesLayoutBy: 'row',
                data: []
            }
        ]
}

export const rightdata_2_2 ={
    tooltip: {
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
    
    },
    color:"#C23531",
    legend: {
        data: ['末级过热器左右温度偏差'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    yAxis: [
        {
            type: 'value',
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
    xAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"
                rotate: 45

            },
            data: [],
        }
    ],
    series: [
        {
            name: '末级过热器左右温度偏差',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: false,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return (params.value ).toFixed(1);
                    },
                  
                }
            },
            data:[],
            itemStyle: {
                normal: {
                    //每根柱子颜色设置
                    color: []
                }
            }
        }
     
    ]
}

export const rightdata_2_2_back ={
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
        trigger: 'axis',
        axisPointer: {            // 坐标轴指示器，坐标轴触发有效
            type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
        },
    
    },
    color:"#C23531",
    legend: {
        data: ['末级过热器左右温度偏差'],
        x: "center",
        y: "30px",

        textStyle: {
            fontSize: 12,//字体大小
            color: '#3e3e3e'//字体颜色
        }
    },
    yAxis: [
        {
            type: 'value',
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
    xAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            axisLabel: {
                show: true,
                textStyle: {
                    color: '#3e3e3e'
                },
                // margin:"2px"
                rotate: 45

            },
            data: [],
        }
    ],
    series: [
        {
            name: '末级过热器左右温度偏差',
            type: 'bar',
            stack: '总量',
            label: {
                normal: {
                    show: false,
                    position: 'inside',
                    color: "white",
                    formatter: function (params) {
                        return (params.value ).toFixed(1);
                    },
                  
                }
            },
            data:[],
            itemStyle: {
                normal: {
                    //每根柱子颜色设置
                    color: []
                }
            }
        }
     
    ]
}
