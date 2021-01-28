
var colors=['#c00020',
    '#c04020',
    '#c00080',
    '#c04080',
    '#20ffff',
    '#a0ffff',
    '#FFCC33',
    '#CC9933',
    '#4000ff',
    '#4040ff',
    '#20a080',
    '#20ff80',
    '#20a000',
    '#a0ffc0'];
var titles=[
    '屏式过热器（左侧）', 
    '屏式过热器（右侧）',
    '高温过热器（左侧）', 
    '高温过热器（右侧）',
    '高温再热器（左侧）', 
    '高温再热器（右侧）',
    '低温再热器（左侧）', 
    '低温再热器（右侧）',
    '低温过热器（左侧）', 
    '低温过热器（右侧）',
    '主省煤器（左侧）', 
    '主省煤器（右侧）',
    '分级省煤器',
    '空气预热器'
];
var selects={
    '屏式过热器（左侧）':false,
    '屏式过热器（右侧）':false,
    '高温过热器（左侧）':false, 
    '高温过热器（右侧）':false,
    '高温再热器（左侧）':false, 
    '高温再热器（右侧）':false,
    '低温再热器（左侧）':false, 
    '低温再热器（右侧）':false,
    '低温过热器（左侧）':false, 
    '低温过热器（右侧）':false,
    '主省煤器（左侧）':false, 
    '主省煤器（右侧）':false,
    '分级省煤器':false,
    '空气预热器':false
};
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
        color: colors,
        legend: {
            data: titles,
            
            x: "center",
            y: "0px",

            textStyle: {
                fontSize: 12,//字体大小
                color: '#3e3e3e'//字体颜色
            },
            selected: selects
        },
        tooltip: {
            trigger: 'axis',
            showContent: true,
            formatter: function (params) {               
                let r='';
                let i=0;

                console.log(JSON.stringify(params));

                for( let b in params){
                    if(i==0){
                        r+=(params[i]?(""+params[i].seriesName+":" + (params[i].value)):"")
                    }else{
                        r+=(params[i]?("<br>"+params[i].seriesName+":" + (params[i].value)):"")
                    }
                    
                    i++;
                }


                // leftdata_2_back.legend.data.forEach(element => {
                //     r+=(params[i]?("<br>"+element+":" + (params[i].value)):"")
                //     i++;
                // });
                // (params[0]?("屏式过热器（左侧）：" + (params[0].value) ):"")
                // + (params[1]?("<br>屏式过热器（右侧）:" + (params[1].value)):"")
                // + (params[2]?("<br>高温过热器（左侧）:" + (params[2].value)):"")
                // + (params[3]?("<br>高温过热器（右侧）:" + (params[3].value)):"")
                // + (params[4]?("<br>高温再热器（左侧）:" + (params[4].value)):"")
                // + (params[5]?("<br>高温再热器（右侧）:" + (params[5].value)):"")
                // + (params[6]?("<br>低温再热器（左侧）:" + (params[6].value)):"")
                // + (params[7]?("<br>低温再热器（右侧）:" + (params[7].value)):"")
                // + (params[8]?("<br>低温过热器（左侧）:" + (params[8].value)):"")
                // + (params[9]?("<br>低温过热器（右侧）:" + (params[9].value)):"")
                // + (params[10]?("<br>主省煤器（左侧）:" + (params[10].value)):"")
                // + (params[11]?("<br>主省煤器（右侧）:" + (params[11].value)):"")
                // + (params[12]?("<br>分级省煤器:" + (params[12].value)):"")
                // + (params[13]?("<br>空气预热器:" + (params[13].value)):"")
                // ;
                return r;
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
            name:"污染率",
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

            // {
            // name:"负荷",
            // gridIndex:0,  
                        
                    
            // axisLabel: {
            //     show: true,
            //     textStyle: {
            //         color: '#3e3e3e'
            //     }
            // },
            // splitLine: {
            //     show: false
            // },
            // scale:true
            // },
		],
        series: [
            {
                name: '屏式过热器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color : colors[0]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '屏式过热器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color: colors[1]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },


            {
                name: '高温过热器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color: colors[2]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '高温过热器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color: colors[3]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '高温再热器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color: colors[4]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '高温再热器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[5]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '低温再热器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[6]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '低温再热器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[7]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },


            {
                name: '低温过热器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[8]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '低温过热器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[9]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },


            {
                name: '主省煤器（左侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[10]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },
            {
                name: '主省煤器（右侧）',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[11]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },


            {
                name: '分级省煤器',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[12]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            },

            {
                name: '空气预热器',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal:
                        {
                            lineStyle: {
                                width: 2,
                                color:colors[13]
                            }
                        }
                },
                seriesLayoutBy: 'row',
                data: []
            }
        ]
}

