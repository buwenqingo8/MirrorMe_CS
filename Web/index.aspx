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

        .btn
{
  
    
   
}

        ul {
            font-size: 14px;
            color: #8f8f94;
        }

        .mui-btn {
            padding: 10px;
            font-size:14px
        }


        * {
            list-style: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            font-size:14px
        }

        .tab1 {
           
            border-top: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
            width: 100%;
            text-align: center;
            font-size:14px
        }

        .menu {
         
            background: #eee;
            height: 40px;
            border-right: #A8C29F solid 1px;
            border-bottom: #A8C29F solid 1px;
            width: 100%;
            text-align: center;
            font-size:14px
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
            font-size:14px
        }

            .menudiv div {
                padding: 15px;
                line-height: 28px;
                font-size:14px
            }

        .off {
            background: #E0E2EB;
            color: #336699;
            font-weight: bold;
            font-size:14px
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
                font-size: 14px;
                color: #000000;
                font-weight: 600;
                text-align: center;
                white-space: nowrap;
                height: 31px;
                line-height: 31px;
                border-top: 1px solid #DBDEE1;
                border-left: 1px solid #DBDEE1;
                border-right: 1px solid #DBDEE1;
                border-bottom: 1px solid #DBDEE1;
                background-color: #F6F8FA;
            }

            table.list td {
                height: 29px;
                line-height: 29px;
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
          left: 40%; /*FF IE7*/
            top: 40%; /*FF IE7*/
            margin-left: -100px !important; /*FF IE7 该值为本身宽的一半 */
            margin-top: -50px !important; /*FF IE7 该值为本身高的一半*/
            margin-top: 0px;
            position: fixed !important; /*FF IE7*/

vertical-align:middle;
            text-align:center;
        }
    </style>


    <script type="text/javascript">
        jQuery(document).ready(function () {

            //setinterval("startrequest()", 1000);

            var site = localStorage.getItem('phone');
            //   alert(site)
            $("#bcTarget").val(site);
            $("#src").val(site);
              $("#Hidden1").val(site);


              $.ajax({
                  type: "POST",
                  url: "index.aspx/getPhone",
                  data: "{'strphone':'" + site + "'}",
                  contentType: "application/json;charset=utf-8",
                  dataType: "json",
                  success: function (data) {
                     
                  },
                  error: function (err) {
                      
                  }
              });
;
        });


        function cc() {
            var site = localStorage.getItem('phone');
            //   alert(site)
            $("#bcTarget").val(site);
            $("#src").val(site);
            $("#Hidden1").val(site);


            $.ajax({
                type: "POST",
                url: "index.aspx/getPhone",
                data: "{'strphone':'" + site + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {

                },
                error: function (err) {

                }
            });

            if (!window.name) { window.name = 'test';  window.location.href = 'index.aspx'; window.location.reload(); }
            else {
               
                window.location.href = 'login.aspx';
            }

        }


        //function startrequest() {
        //    if (!window.name) { window.name = 'test'; window.location.href = 'index.aspx'; window.location.reload(); }
        //    else {

        //        window.location.href = 'login.aspx';
        //    }
        //}


        function bb () {
            var site = localStorage.getItem('phone');
            //   alert(site)
            $("#bcTarget").val(site);
            $("#src").val(site);
            $("#Hidden1").val(site);

        }

        function code11() {
            $("#bcTarget").empty().barcode($("#src").val(), "code11", { barWidth: 1, barHeight: 40, showHRI: false });
        }

        function code39() {
            $("#bcTarget").empty().barcode($("#src").val(), "code128", { barWidth: 2, barHeight: 80, showHRI: false });
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
        //function code39_2() {
        //    $("#bcTarget2").empty().barcode($("#src2").val(), "code39", { barWidth: 1, barHeight: 50, showHRI: false });
        //}

        // 卷号
        function code39_2() {
            $("#bcTarget2").empty().barcode($("#src2").val(), "code128", { barWidth: 2, barHeight: 200, showHRI: false });
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


<body style="font-size:14px">
    <form id="form1" runat="server" >
        
          <!--卷号层-->
                <div id="pop" class="pop" style="display: none">
                    <div id="bcTarget2" style="margin: 0px; padding: 0; width: 100%; text-align: center; margin-left: auto; margin-right: auto;vertical-align:middle;">
                    </div>
                    <div style="text-align: center; margin: 0; padding: 0;">
                        <input id="src2" value="15700000000" style="border-style: none; border-color: inherit; border-width: 0px; background-color: transparent; width: 165px;" readonly="readonly" />
                    </div>
                </div>
             
        <div id="main" class="mui-content">
            <div class="mui-content-padded">

                <div class="logo">
                    <br />
                    <img style="width: 72px; height: 72px;" src="images/普通-01.png" runat="server" id="imgVIP"/>
                    <br />
                    <span style="font-size: 16px;">
                         
                        <label id="txtName" style="border: 0; background-color: transparent;font-size:16px"  runat="server"></label>
                         
                   是  <label id="txtVIP" style="border: 0; background-color: transparent;font-size:16px"  runat="server"></label></span>
                    <input id="Hidden1" type="hidden" runat="server" />
                </div>
                <br /> 
                <div class="private_wrap">


                    <strong></strong>

                    <div class="log_info">
                        <div class="profile_txt">



                            <div id="bcTarget" style="margin: 0px; padding: 0; width: 100%; text-align: center; margin-left: auto; margin-right: auto;">
                            </div>

                            <div style="text-align: center; margin: 0; padding: 0;">
                                <input id="src" value="1570008562612" style="border-style: none; border-color: inherit; border-width: 0px; background-color: transparent; width: 124px;"  readonly="readonly"/>
                            </div>


                        </div>



                    </div>
                </div>
                <div class="tab1" id="tab1">
                    <div class="menu">
                        <ul>
                            <li id="one2" onclick="setTab('one',2)"  style="width:33%">
                                <img style="width: 40px; height: 40px;" src="images/优惠券-01.png" />( <label id="lblYHQ" style="border: 0; background-color: transparent;"  runat="server"></label>张)</li>
                            <li id="one1" onclick="setTab('one',1)" style="width:33%">
                                <img style="width: 40px; height: 40px;" src="images/积分-01.png" />( <label id="lblJF" style="border: 0; background-color: transparent;"  runat="server"></label>)</li>
                            
                            <li id="one3" onclick="setTab('one',3)" style="width:33%">个人信息</li>
                        </ul>
                    </div>
                    <div class="menudiv">
                        
                        <div id="con_one_2" style=" overflow:scroll;">
                            <table class="list" style="table-layout: auto; overflow:scroll;">
                                <tr>

                                    <th>券名
                                    </th>
                                    <th>券号
                                    </th>
                                    <th>使用说明
                                    </th>
                                    <th>有效期
                                    </th>

                                </tr>
                                <asp:Repeater runat="server" ID="rtInvite" >
                                    <ItemTemplate>
                                        <tr>

                                            <td><%# (Container.DataItem as APIManage.CardJson).CERTINAME%>
                                            </td>
                                            <td><%--<%# (Container.DataItem as APIManage.CardJson).CERTINO%>--%>

                                                <asp:HiddenField ID="hidnum" runat="server" Value='<%# (Container.DataItem as APIManage.CardJson).CERTINO %>'></asp:HiddenField>

                                                <a id="aCode" runat="server" style="color: Blue; text-decoration: underline" onclick="openForm(this);"><%# (Container.DataItem as APIManage.CardJson).CERTINO %></a>
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

                        <div id="con_one_1" style="vertical-align:middle">

                         积分月份：   <select id="selYY" runat="server" style="vertical-align:middle">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                                <option>7</option>
                                <option>8</option>
                                <option>9</option>
                                <option>10</option>
                                 <option>11</option>
                                <option>12</option>


                            </select>

                            <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click"    CssClass="btn"   />
                            <br />
                              <br />
                            
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

                                            <td><%# (Container.DataItem as APIManage.PointVOXML).JzDate%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.PointVOXML).OrgName%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.PointVOXML).SsTotal%>
                                            </td>
                                            <td><%# (Container.DataItem as APIManage.PointVOXML).JfTotal%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                        </div>

                        <div id="con_one_3">


                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">姓名:</label>
                                <input id="txtname1" type="text" value="null" style="border: 0; background-color: transparent; font-size:14px"  runat="server" />
                            </div>
                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">手机:</label>
                                <input id="txtphone" type="text" style="border: 0; background-color: transparent; font-size:14px" value="null" runat="server"/>
                            </div>
                            <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">出生:</label>
                                <input id="txtbrith" type="text" style="border: 0; background-color: transparent; font-size:14px" value="null" runat="server"/>
                            </div>
                           <%-- <div style="text-align: center; margin: 0; padding: 0;">
                                <label style="float: left;">性别:</label>
                                <input id="txtsex" type="text" style="border: 0; background-color: transparent; font-size:14px" value="null" runat="server"/>
                            </div>--%>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

   

</html>
