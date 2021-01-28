
export const kyqhk_back=(title,wornline)=>{
    let t=title;
    let x=null;
    let n="偏高线";
    let c="red";
    if(title.indexOf("侧效率")!=-1){
        n="偏低线";
        c="green";
    }
    if(wornline!=0){
        //markLine
        x= 
          {   //添加警戒线
                        symbol:"none",               //去掉警戒线最后面的箭头
                        name:n,
                        silent:true,
                        label:{
                            position:"end",         //将警示值放在哪个位置，三个值“start”,"middle","end"  开始  中点 结束
                            formatter: n,
                            color:c,
                            fontSize:14
                        },
                        data : [{
                            silent:true,             //鼠标悬停事件  true没有，false有
                            lineStyle:{               //警戒线的样式  ，虚实  颜色
                                type:"solid",
                                color:c
                            },
                            name: n,
                            yAxis: wornline
                        }]
                    }
                    ;
    }else{
        x={};
    }
    return {
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
            data: [t],
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
                name: t,
                type: 'line',
                smooth: true,
                // seriesLayoutBy: 'row',
                data:[],
                markLine:x
            }
        ]
    }
};


