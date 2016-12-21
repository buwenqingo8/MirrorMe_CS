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
           
            border-top: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
            width: 100%;
            text-align: center;
        }

        .menu {
         
            background: #eee;
            height: 40px;
            border-right: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
            width: 100%;
            text-align: center;
        }

        li {
            float: left;
            width: 99px;
            text-align: center;
            line-height: 40px;
            height: 40px;
            cursor: pointer;
            border-left: #A8C29F solid 1px;
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



        table {
            border: 0;
            border-collapse: collapse;
        }

        td, th {
            padding-left: 3px;
            padding-right: 3px;
            border: 0;
            white-space: nowrap;
            border-collapse: collapse;
        }

            td.dialog-header {
                font-weight: 600;
                text-align: left;
                font-size: 14px;
                color: #000000;
                background-color: #FFFFFF;
                border-bottom-color: #A4ABB2;
                border-bottom-style: solid;
                border-bottom-width: 1px;
                height: 48px;
                vertical-align: middle;
                padding: 5px;
            }

        .file {
            width: 100%;
            height: 20px;
            padding-top: 2px;
            direction: ltr;
        }

        .hidden {
            display: none;
        }

        /*
*页面 Grid 部分的样式
***************************************/
        table.list {
            width: 100%;
            margin-top: 0px;
            border-width: 1px;
            border-style: solid;
            border-color: #A5ACB5;
            background-color: #FFFFFF;
        }

            table.list th, .footer {
                font-size: 12px;
                color: #000000;
                font-weight: 600;
                text-align: center;
                white-space: nowrap;
                height: 21px;
                line-height: 21px;
                border-top: 1px solid #DBDEE1;
                border-left: 1px solid #DBDEE1;
                border-right: 1px solid #DBDEE1;
                border-bottom: 1px solid #DBDEE1;
                background-color: #F6F8FA;
            }

            table.list td {
                height: 19px;
                line-height: 19px;
                padding-top: 1px;
                margin-bottom: 1px;
                border-bottom: 1px solid #DBDEE1;
                cursor: hand;
            }

        .select-row {
            background-color: #A7CDF0;
        }

        .hover-row {
            background-color: #CEE3F6;
        }

        td.checkbox, th.checkbox {
            width: 20px;
        }

        .logo {
            width: 100%;
            text-align: center;
        }

        .pop {
            position: absolute;
            /*left: 30%;
            top: 30%;*/
            background: #eee;
            border: 1px solid #4b8e63;
            left: 50%; /*FF IE7*/
            top: 50%; /*FF IE7*/
            margin-left: -100px !important; /*FF IE7 该值为本身宽的一半 */
            margin-top: -60px !important; /*FF IE7 该值为本身高的一半*/
            margin-top: 0px;
            position: fixed !important; /*FF IE7*/
        }
    </style>


    <script type="text/javascript">
        jQuery(document).ready(function () {
            var site = localStorage.getItem('phone');
            //   alert(site)
            $("#bcTarget").val(site);
            $("#src").val(site);
            //   $("#Hidden1").val(site);

            $("#bcTarget").text(site);
            $("#src").text(site);
            //   $("#Hidden1").text(site);
        });

        function code11() {
            $("#bcTarget").empty().barcode($("#src").val(), "code11", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function code39() {
            $("#bcTarget").empty().barcode($("#src").val(), "code39", { barWidth: 1, barHeight: 50, showHRI: false });
        }

        function code93() {
            $("#bcTarget").empty().barcode($("#src").val(), "code93", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function code128() {
            $("#bcTarget").empty().barcode($("#src").val(), "code128", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function ean8() {
            $("#bcTarget").empty().barcode($("#src").val(), "ean8", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function ean13() {
            $("#bcTarget").empty().barcode($("#src").val(), "ean13", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function std25() {
            $("#bcTarget").empty().barcode($("#src").val(), "std25", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function int25() {
            $("#bcTarget").empty().barcode($("#src").val(), "int25", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function msi() {
            $("#bcTarget").empty().barcode($("#src").val(), "msi", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function datamatrix() {
            $("#bcTarget").empty().barcode($("#src").val(), "datamatrix", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        //卷号
        function code39_2() {
            $("#bcTarget2").empty().barcode($("#src2").val(), "code39", { barWidth: 1, barHeight: 50, showHRI: false });
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
            code39();
        }


        function openForm(ctl) {
            if (ctl == null) {
                alert('控件丢失!');
                return;
            }

            var id = document.getElementById(ctl.id.replace('aCode', 'hidnum')).value;

            if (id == null || id == '') {
                alert('卷号丢失!');
                return;
            }
            document.getElementById("src2").value = id;

            show();

        }


    </script>
    <script type="text/javascript">
        var EX = {
            addEvent: function (k, v) {
                var me = this;
                if (me.addEventListener)
                    me.addEventListener(k, v, false);
                else if (me.attachEvent)
                    me.attachEvent("on" + k, v);
                else
                    me["on" + k] = v;
            },
            removeEvent: function (k, v) {
                var me = this;
                if (me.removeEventListener)
                    me.removeEventListener(k, v, false);
                else if (me.detachEvent)
                    me.detachEvent("on" + k, v);
                else
                    me["on" + k] = null;
            },
            stop: function (evt) {
                evt = evt || window.event;
                evt.stopPropagation ? evt.stopPropagation() : evt.cancelBubble = true;
            }
        };
       // document.getElementById('pop').onclick = EX.stop;
        var url = '#';
        function show() {
            
            code39_2();//卷号
            var o = document.getElementById('pop');
            o.style.display = "";
            setTimeout(function () { EX.addEvent.call(document, 'click', hide); });
            var main = document.getElementById('main');
            main.style.display = "none";
        }
        function hide() {
            var o = document.getElementById('pop');
            o.style.display = "none";
            EX.removeEvent.call(document, 'click', hide);
            var main = document.getElementById('main');
            main.style.display = "";
        }





    </script>

</head>


<body>
    <form id="form1" runat="server">
        
          <!--卷号层-->
                <div id="pop" class="pop" style="display: none">
                    <div id="bcTarget2" style="margin: 0px; padding: 0; width: 100%; text-align: center; margin-left: auto; margin-right: auto;">
                    </div>
                    <div style="text-align: center; margin: 0; padding: 0;">
                        <input id="src2" value="15700000000" style="border-style: none; border-color: inherit; border-width: 0px; background-color: transparent; width: 124px;" />
                    </div>
                </div>
             
        <div id="main" class="mui-content">
            <div class="mui-content-padded">

                <div class="logo">
                    <br />
                    <img style="width: 72px; height: 72px;" src="images/普通-01.png" />
                    <br />
                    <span style="font-size: 15px;">*** 会员是 普通会员</span>
                </div>

                <div class="private_wrap">


                    <strong>会员卡</strong>

                    <div class="log_info">
                        <div class="profile_txt">



                            <div id="bcTarget" style="margin: 0px; padding: 0; width: 100%; text-align: center; margin-left: auto; margin-right: auto;">
                            </div>

                            <div style="text-align: center; margin: 0; padding: 0;">
                                <input id="src" value="1570008562612" style="border-style: none; border-color: inherit; border-width: 0px; background-color: transparent; width: 124px;" />
                            </div>


                        </div>



                    </div>
                </div>
                <div class="tab1" id="tab1">
                    <div class="menu">
                        <ul>

                            <li id="one1" onclick="setTab('one',1)">
                                <img style="width: 40px; height: 40px;" src="images/积分-01.png" />(0)</li>
                            <li id="one2" onclick="setTab('one',2)">
                                <img style="width: 40px; height: 40px;" src="images/优惠券-01.png" />(0张)</li>
                            <li id="one3" onclick="setTab('one',3)">个人信息</li>
                        </ul>
                    </div>
                    <div class="menudiv">
                        <div id="con_one_1">
                            <table class="list">
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
                                    <th>卷号
                                    </th>
                                    <th>使用条件
                                    </th>
                                    <th>有效期
                                    </th>

                                </tr>
                                <asp:Repeater runat="server" ID="rtInvite">
                                    <ItemTemplate>
                                        <tr>

                                            <td><%# (Container.DataItem as APIManage.CardJson).CERTINAME%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.CardJson).CERTINO%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.CardJson).CXREMARK%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.CardJson).USENDDATE%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </table>
                        </div>
                        <div id="con_one_3">


                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">姓名:</label>
                                <input id="name" type="text" value="null" style="border: 0; background-color: transparent;" />
                            </div>
                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">手机:</label>
                                <input id="phone" type="text" style="border: 0; background-color: transparent;" value="null" />
                            </div>
                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">出生年月:</label>
                                <input id="brith" type="text" style="border: 0; background-color: transparent;" value="null" />
                            </div>
                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">性别:</label>
                                <input id="sex" type="text" style="border: 0; background-color: transparent;" value="null" />
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

   

</html>
