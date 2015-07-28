<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapChart.aspx.cs" Inherits="Demo.EChart.MapChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EChart</title>
</head>
<body>
    <div id="main" style="height: 800px;"></div>
    <%--  <script src="../Scripts/jquery-2.1.3.min.js"></script>--%>    
    <script src="../Scripts/echarts-2.1.10/build/dist/echarts.js" type="text/javascript"></script>
    <script src="../Scripts/echarts-2.1.10/doc/asset/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">


        require.config({
            paths: {
                echarts: '../Scripts/echarts-2.1.10/build/dist'
            }
        });

        require(
            [
                'echarts',                
                'echarts/chart/map'
            ],
            function (ec) {

                require('echarts/util/mapData/params').params.continent = {
                    getGeoJson: function (callback) {                        
                        $.getJSON('../Scripts/echarts-2.1.10/src/util/mapData/rawData/geoJson/<%=AREA%>.json', callback);
                    }
                }

                var myChart = ec.init(document.getElementById('main'));

                option = {

                    tooltip: {
                        trigger: 'item',
                        formatter: function (params) {
                            var value = params.value;
                            return params.seriesName + '<br/>' + params.name + ' : ' + value;
                        }
                    },
                    toolbox: {
                        show: true,
                        orient: 'vertical',
                        x: 'right',
                        y: 'center',
                        feature: {
                            mark: { show: true },
                            dataView: { show: true, readOnly: false },
                            restore: { show: true },
                            saveAsImage: { show: true }
                        }
                    },
                    dataRange: {
                        min: 0,
                        max: 1000,
                        text: ['多', '少'],
                        splitNumber: 0,
                        color: ['#ffe4b5', '#c0c0c0', '#a9a9a9']
                    },
                    series: [
                        {
                            name: '客戶分佈圖',
                            type: 'map',
                            mapType: 'continent',
                            roam: true,
                            selectedMode: 'single',
                            itemStyle: {
                                normal: { label: { show: false } },
                                emphasis: { label: { show: false } }
                            },
                            data: $.parseJSON(callMethod('GetData', {})),

                            nameMap: {<%=NameMap%> }
                        }
                    ]
                };

                var ecConfig = require('echarts/config');
                myChart.on(ecConfig.EVENT.MAP_SELECTED, function (param) {
                    var selected = param.selected;
                    var selectedProvince;
                    var name;

                    for (var p in selected) {
                        if (selected[p]) {
                            selectedProvince = p;
                        }
                    }

                    //for (var i = 0, l = option.series[0].data.length; i < l; i++) {
                    //    name = option.series[0].data[i].name;
                    //    option.series[0].data[i].selected = selected[name];
                    //    if (selected[name]) {
                    //        selectedProvince = name;
                    //    }
                    //}              

                    if (typeof selectedProvince == 'undefined') {
                        option.series.splice(1);
                        option.legend = null;
                        option.dataRange = null;
                        myChart.setOption(option, true);
                        return;
                    }

                    window.location.replace('<%=URL%>?AR=' + selectedProvince);

                });

                myChart.setOption(option);
            });

            function callMethod(func, parm) {
                var data;

                $.ajax({
                    type: "POST",
                    url: "MapChart.aspx/" + func,
                    data: JSON.stringify(parm),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (result) { data = result.d; },
                    failure: function () {
                        valid = null;
                    }
                });

                return data;
            }


    </script>
</body>
</html>
