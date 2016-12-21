<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gbk" http-equiv="Content-Type" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta content="会员卡" name="description" />
    <meta content="telephone=no" name="format-detection" />
    <title>会员卡</title>
    <link href="css/commonindex.css" rel="stylesheet" />
    <link href="css/mui.min.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="js/jquery-barcode.js"></script>
    <script src="js/mui.min.js"></script>
    <script src="js/app.js"></script>
   
    <style>
        ul {
            font-size: 14px;
            color: #8f8f94;
        }

        .mui-btn {
            padding: 10px;
        }


        * {
            list-style: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }

        .tab1 {
            width: 100%;
            border-top: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
           
        }

        .menu {
            width: 100%;
            background: #eee;
            height: 28px;
            border-right: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
        }

        li {
            float: left;
            width: 99px;
            text-align: center;
            line-height: 28px;
            height: 28px;
            cursor: pointer;
            border-left: #A8C29F solid 1px;
            border-right: #A8C29F solid 1px;
            color: #666;
            font-size: 14px;
            overflow: hidden;
        }

        .menudiv {
            width: 100%;
            height: 100%;
            border-left: #A8C29F solid 1px;
            border-right: #A8C29F solid 1px;
            border-top: 0;
            background: #fefefe;
        }

            .menudiv div {
                padding: 15px;
                line-height: 28px;
            }

        .off {
            background: #E0E2EB;
            color: #336699;
            font-weight: bold;
        }


        
table{ border:0; border-collapse:collapse;}
td,th{ padding-left:3px; padding-right:3px;border:0;white-space:nowrap; border-collapse:collapse;}
td.dialog-header {font-weight:600; text-align:left; font-size:14px;color:#000000; background-color:#FFFFFF;border-bottom-color:#A4ABB2;border-bottom-style: solid;border-bottom-width: 1px;height:48px;vertical-align:	middle;padding:5px;}
.file{width:100%;height:20px;padding-top:2px;direction:ltr;}
.hidden {display:none;}

/*
*页面 Grid 部分的样式
***************************************/
table.list {width:100%;margin-top:0px; border-width: 1px; border-style: solid;border-color:#A5ACB5; background-color:#FFFFFF;}
table.list th,.footer {font-size:12px; color:#000000; font-weight:600; text-align:center;white-space:nowrap; height:21px; line-height:21px; border-top: 1px solid #DBDEE1;border-left: 1px solid #DBDEE1;border-right: 1px solid #DBDEE1;border-bottom: 1px solid #DBDEE1;background-color:#F6F8FA;}
table.list td {height:19px;line-height:19px;padding-top: 1px;margin-bottom: 1px;border-bottom: 1px solid #DBDEE1;cursor:hand;}
.select-row{background-color:#A7CDF0;}
.hover-row{	background-color:#CEE3F6;}
td.checkbox,th.checkbox{ width:20px; }



    </style>


    <script type="text/javascript">
        jQuery(document).ready(function getLocalStorage() {
            var site = localStorage.getItem("phone");
            $("#bcTarget").val = site;
        });

        function code11() {
            $("#bcTarget").empty().barcode($("#src").val(), "code11", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function code39() {
            $("#bcTarget").empty().barcode($("#src").val(), "code39", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function code93() {
            $("#bcTarget").empty().barcode($("#src").val(), "code93", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function code128() {
            $("#bcTarget").empty().barcode($("#src").val(), "code128", { barWidth: 1, barHeight: 30, showHRI: false });
        }

        function ean8() {
            $("#bcTarget").empty().barcode($("#src").val(), "ean8", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function ean13() {
            $("#bcTarget").empty().barcode($("#src").val(), "ean13", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function std25() {
            $("#bcTarget").empty().barcode($("#src").val(), "std25", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function int25() {
            $("#bcTarget").empty().barcode($("#src").val(), "int25", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function msi() {
            $("#bcTarget").empty().barcode($("#src").val(), "msi", { barWidth: 2, barHeight: 30, showHRI: false });
        }

        function datamatrix() {
            $("#bcTarget").empty().barcode($("#src").val(), "datamatrix", { barWidth: 2, barHeight: 30, showHRI: false });
        }



      
        </script>


    <script type="text/javascript">
        function setTab(name, cursel) {
            cursel_0 = cursel;
            for (var i = 1; i <= links_len; i++) {
                var menu = document.getElementById(name + i);
                var menudiv = document.getElementById("con_" + name + "_" + i);
                if (i == cursel) {
                    menu.className = "off";
                    menudiv.style.display = "block";
                }
                else {
                    menu.className = "";
                    menudiv.style.display = "none";
                }
            }
        }
        function Next() {
            cursel_0++;
            if (cursel_0 > links_len) cursel_0 = 1
            setTab(name_0, cursel_0);
        }
        var name_0 = 'one';
        var cursel_0 = 1;
        var links_len, iIntervalId;
        onload = function () {
            var links = document.getElementById("tab1").getElementsByTagName('li')
            links_len = links.length;
            for (var i = 0; i < links_len; i++) {
                links[i].onmouseover = function () {
                    clearInterval(iIntervalId);
                }
            }
            document.getElementById("con_" + name_0 + "_" + links_len).parentNode.onmouseover = function () {
                clearInterval(iIntervalId);
            }
            setTab(name_0, cursel_0);
        }
 </script> 
</head>


<body>
    <form id="form1" runat="server">

        <div class="mui-content">
            <div class="mui-content-padded">

                <div class="private_wrap">


                    <strong>个人资料</strong>

                    <div class="log_info">
                        <div class="profile_txt">

                            <input id="src" value="11225921991" />
                            <input type="button" onclick='code39()' value="此方法放到onload" />
                            <div id="bcTarget" style="margin: 10px 0px; width: 80%;"></div>





                            <div>
                                <label style="float: left;">姓名:</label>
                                <input id="name" type="text" value="null" style="border: 0; background-color: transparent;" />
                            </div>
                            <div>
                                <label style="float: left;">手机:</label>
                                <input id="phone" type="text" style="border: 0; background-color: transparent;" value="null" />
                                <input id="Hidden1" type="hidden"  runat="server"/>
                            </div>
                            <div>
                                <label style="float: left;">出生年月:</label>
                                <input id="brith" type="text" style="border: 0; background-color: transparent;" value="null" />
                            </div>
                            <div>
                                <label style="float: left;">性别:</label>
                                <input id="sex" type="text" style="border: 0; background-color: transparent;" value="null" />
                            </div>
                        </div>



                    </div>
                </div>
                <div class="tab1" id="tab1">
                    <div class="menu">
                        <ul >

                            <li id="one1" onclick="setTab('one',1)">积分</li>
                            <li id="one2" onclick="setTab('one',2)">优惠卷</li>
                            
                        </ul>
                    </div>
                    <div class="menudiv">
                        <div id="con_one_1">
                            <table class="list" >
                                <tr>

                                    <th>日期
                                    </th>
                                    <th>门店
                                    </th>


                                    <th>金额
                                    </th>

                                    <th>积分
                                    </th>

                                </tr>
                                <asp:Repeater runat="server" ID="rtpContact">
                                    <ItemTemplate>
                                        <tr>

                                            <td>1
                                            </td>
                                            <td>2
                                            </td>
                                            <td>3
                                            </td>
                                            <td>4
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                        </div>
                        <div id="con_one_2">
                            <table class="list">
                                <tr>

                                    <th>卷名
                                    </th>
                                    <th >卷号
                                    </th>
                                    <th>使用条件
                                    </th>
                                    <th>有效期
                                    </th>

                                </tr>
                                <asp:Repeater runat="server" ID="rtInvite">
                                    <ItemTemplate>
                                        <tr>

                                            <td>1
                                            </td>
                                            <td>2
                                            </td>
                                            <td>3
                                            </td>
                                            <td>4
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>


</html>
