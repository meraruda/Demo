<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Portal.aspx.cs" Inherits="Demo.Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .page-header {
            margin: 0px 0 20px;
            background-color: #1e50a2;
            color: #fff;
            padding: 18px;
        }

            .page-header > a {
                color: #fff;
                text-shadow: #a9a9a9 1px 1px 3px;
            }

        .nav-pills > li.active > a,
        .nav-pills > li.active > a:hover,
        .nav-pills > li.active > a:focus {
            color: #fff;
            background-color: #a9a9a9;
        }

        .nav-pills > li > a {
            border-radius: 0;
        }

        #list .list-group {
            padding-top: 40px;
        }

        #list .list-group-item {
            color: #888888;
            border: 0;
            padding: 0 0 0 10px;
            margin: 8px;
        }

            #list .list-group-item > a {
                color: #888888;
            }

            #list .list-group-item:first-child {
                border-top: 0;
                border-radius: 0;
            }

            #list .list-group-item:last-child {
                border-radius: 0;
            }

            #list .list-group-item:hover {
                border-left: 3px double #cdcdcd;
            }

            #list .list-group-item > span {
                float: right;
            }

        #subjectlist .list-group-item {
            border: 0;
            border-top: 1px solid #cdcdcd;
        }

            #subjectlist .list-group-item:first-child {
                border-top: 0;
                border-radius: 0;
            }

            #subjectlist .list-group-item:last-child {
                border-bottom: 1px solid #cdcdcd;
                border-radius: 0;
            }

            #subjectlist .list-group-item:hover {
                background-color: #f5f5f5;
            }

        #myCarousel .carousel-inner > .item {
            text-align: center;
        }

        #myCarousel .carousel-indicators {
            height: 90px;
        }

        #myCarousel .carousel-inner {
            height: 90px;
        }

        #myCarousel .carousel-control {            
         
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav nav-pills">
            <li id="N1" class="active"><a href="#">Home</a></li>
            <li id="N2"><a href="#">Page1</a></li>
            <li id="N3"><a href="#">Page2</a></li>
            <li id="N4"><a href="#">Page3</a></li>
            <li id="N5"><a href="#">Page4</a></li>
            <li id="N6"><a href="#">Page5</a></li>
        </ul>
        <div class="page-header">
            <a style="z-index: 3;" herf="#">
                <h2>DEMO</h2>
            </a>
            <div>
                <div class="page-header">
                    <div id="myCarousel" class="carousel slide">
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="item active">
                                <img class="center-block" src="Images/.NET.png" />
                                <%--  <div class="container">
                                    <table class="table" style="text-align: center" align="center">
                                        <tbody>
                                            <tr>
                                                <td class="HeaderCss" colspan="7">定期會議使用紀錄 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="HeaderCss">固定日期</td>
                                                <td class="HeaderCss">場地</td>
                                                <td class="HeaderCss">擔當人員</td>
                                                <td class="HeaderCss">部門</td>
                                                <td class="HeaderCss">起始時間</td>
                                                <td class="HeaderCss">截止時間</td>
                                                <td class="HeaderCss">會議內容</td>
                                            </tr>
                                            <tr>
                                                <td>每週一</td>
                                                <td>第二會議室</td>
                                                <td>生產會議</td>
                                                <td>生產本部</td>
                                                <td>13:00</td>
                                                <td>17:00</td>
                                                <td>生產會議</td>
                                            </tr>
                                            <tr>
                                                <td>每週一</td>
                                                <td>第三會議室</td>
                                                <td>江映霞
                                                </td>
                                                <td>專案銷售課</td>
                                                <td>08:00</td>
                                                <td>10:00</td>
                                                <td>專案銷售課週會</td>
                                            </tr>
                                            <tr>
                                                <td>每週二</td>
                                                <td>第五會議室</td>
                                                <td>陳建宏</td>
                                                <td>第一事業本部</td>
                                                <td>10:00</td>
                                                <td>12:00</td>
                                                <td>生產會議</td>
                                            </tr>
                                            <tr>
                                                <td>每月第一週的星期六</td>
                                                <td>第一會議室</td>
                                                <td>林春錦</td>
                                                <td>業務部</td>
                                                <td colspan="2">全天</td>
                                                <td>月會</td>
                                            </tr>
                                            <tr>
                                                <td>每週二</td>
                                                <td>營業本部會議室一</td>
                                                <td>江映霞</td>
                                                <td>客訴中心</td>
                                                <td>08:00</td>
                                                <td>11:00</td>
                                                <td>客訴內部會議</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>--%>
                            </div>
                            <div class="item">
                                <img class="center-block" src="Images/Css.png" />
                            </div>
                            <div class="item">
                                <img class="center-block" src="Images/Jquery.png" />
                            </div>
                        </div>
                        <a class="carousel-control left" href="#myCarousel"
                            data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
                        <a class="carousel-control right" href="#myCarousel"
                            data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
                    </div>
                </div>
            </div>
        </div>
        <div id="a" class="container">
            <div class="row">
                <div class="col-lg-10">
                    <h2><strong>Home</strong></h2>
                    <hr />
                    <ul id="subjectlist" class="list-group">
                        <li class="list-group-item">
                            <blockquote>
                                <a href="#">
                                    <h4>Subject1</h4>
                                </a>
                                <small>Some context</small>
                            </blockquote>
                        </li>
                        <li class="list-group-item">
                            <blockquote>
                                <a href="#">
                                    <h4>Subject2</h4>
                                </a>
                                <small>Some context</small>
                            </blockquote>
                        </li>
                        <li class="list-group-item">
                            <blockquote>
                                <a href="#">
                                    <h4>Subject3</h4>
                                </a>
                                <small>Some context</small>
                            </blockquote>
                        </li>
                        <li class="list-group-item">
                            <blockquote>
                                <a href="#">
                                    <h4>Subject4&nbsp<span class="badge">new</span></h4>
                                </a>
                                <small>Some context</small>
                            </blockquote>
                        </li>
                    </ul>
                </div>
                <div id="list" class="col-lg-2">
                    <ul class="list-group">
                        <li class="list-group-item"><a href="#">SomeListOne</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListTwo</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListThree</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListFour</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListFive</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListSix</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                        <li class="list-group-item"><a href="#">SomeListSeven</a><span class="glyphicon glyphicon-chevron-right"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(
            function () {
                $('.nav-pills li').each(
                    function () {
                        $(this).bind('click', function () {

                            if (!$(this).hasClass('active')) {
                                $('.nav-pills .active').removeClass('active');
                            }

                            $(this).addClass('active');
                        });
                    }
                )
            });


    </script>
</body>
</html>
