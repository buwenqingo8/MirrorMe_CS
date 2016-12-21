<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default"  CodePage="Default" ClassName="Default" CodeBehind="~/Default.aspx.cs" CodeFileBaseClass="Default"  %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gbk" http-equiv="Content-Type" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta content="注册" name="description" />
    <meta content="telephone=no" name="format-detection" />
    <link href="css/touch.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/normalize3.0.2.min.css" />
    <link rel="stylesheet" href="css/style.css?v=7" />
    <link href="css/mobiscroll.css" rel="stylesheet" />
    <link href="css/mobiscroll_date.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/mobiscroll_date.js" charset="gb2312"></script>
    <script src="js/mobiscroll.js"></script>
    <script type="text/javascript">

        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({
                    scrollTop: $(this.hash).offset().top
                }, 1000);
            });
            //登录
            $('#submit_btn').click(function () {
                if ($('#name').val() == '') {
                    show_err_msg('姓名(会员名)还没填呢！');
                    $('#name').focus();
                } else if ($('#phone').val() == '') {
                    show_err_msg('手机还没填呢！');
                    $('#phone').focus();
                
                } else if ($('#USER_AGE').val() == '') {
                    show_err_msg('生日还没填呢！');
                    $('#USER_AGE').focus();
                }
                else {
                    //ajax提交表单，
                    $.ajax({
                        type: "POST",
                        //        dataType: "text",
                        async: false,
                        cache: false,
                        //url: "http://202.107.243.43:10939/Ajax/login.ashx?user=" + $('#user').val() + "&password=" + $('#password').val() + "&r=" + Math.random(),
                        url: "Default.aspx/GetRegister",
                        data: "{'phone':'" + $('#phone').val() + "','gender':'" + $('input[name="sex1"]:checked ').val() + "','memName':'" + name + "','birthday':'" + USER_AGE + "','gender':'" + txtname + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                         
                            if (data == "1223") {
                                show_err_msg("卡面号重复!");
                            } else if (data == "1221") {
                                show_err_msg("手机号已存在，请登陆!");
                            }
                            else if (data == "1222") {
                                show_err_msg("证件号重复!");
                            } else if (data == "0") {
                                show_msg("登录成功", "main.html?userCode=" + userCode + "&r=" + Math.random());
                            }
                        }
                    });
                }
            });
        });

        $(function () {
            var currYear = (new Date()).getFullYear();
            var opt = {};
            opt.date = { preset: 'date' };
            opt.datetime = { preset: 'datetime' };
            opt.time = { preset: 'time' };
            opt.default = {
                theme: 'android-ics light', //皮肤样式
                display: 'modal', //显示方式 
                mode: 'scroller', //日期选择模式
                dateFormat: 'yyyy-mm-dd',
                lang: 'zh',
                showNow: true,
                nowText: "今天",
                startYear: currYear - 50, //开始年份
                endYear: currYear + 10 //结束年份
            };

            $("#USER_AGE").mobiscroll($.extend(opt['date'], opt['default']));

        });


        var countdown = 60;
        function settime(obj) {

            if (countdown == 0) {
                obj.removeAttribute("disabled");
                obj.value = "免费获取验证码";
                countdown = 60;
                return;
            } else {
                obj.setAttribute("disabled", true);
                obj.value = "重新发送(" + countdown + ")";
                countdown--;
            }
            setTimeout(function () {
                settime(obj)
            }
                , 1000)
        };


        function none(obj) {
            if (document.getElementById('huiyuan').style.display == 'none') {
                document.getElementById('huiyuan').style.display = 'block';
            }
            else {
                document.getElementById('huiyuan').style.display = 'none'
            }

        };

        var msgdsq;
        //错误时：提示调用方法
        function show_err_msg(msg) {
            $('.msg_bg').html('');
            clearTimeout(msgdsq);
            $('body').append('<div class="sub_err" style="position:absolute;top:60px;left:0;width:500px;z-index:999999;"></div>');
            var errhtml = '<div  class="bac" style="padding:8px 0px;border:1px solid #ff0000;width:100%;margin:0 auto;background-color:#fff;color:#B90802;border:3px #ff0000 solid;text-align:center;font-size:16px;font-family:微软雅黑;"><img style="margin-right:10px;" src="images/error.png">';
            var errhtmlfoot = '</div>';
            $('.msg_bg').height($(document).height());
            $('.sub_err').html(errhtml + msg + errhtmlfoot);
            var left = ($(document).width() - 500) / 2;
            $('.sub_err').css({
                'left': left + 'px'
            });
            var scroll_height = $(document).scrollTop();
            $('.sub_err').animate({
                'top': scroll_height + 120
            }, 300);
            msgdsq = setTimeout(function () {
                $('.sub_err').animate({
                    'top': scroll_height + 80
                }, 300);
                setTimeout(function () {
                    $('.msg_bg').remove();
                    $('.sub_err').remove();
                }, 300);
            }, "1000");
        };
        //正确时：提示调用方法
        function show_msg(msg, url) {
            $('.msg_bg').html('');
            clearTimeout(msgdsq);
            $('body').append('<div class="sub_err" style="position:absolute;top:60px;left:0;width:500px;z-index:999999;"></div>');
            var htmltop = '<div class="bac" style="padding:8px 0px;border:1px solid #090;width:100%;margin:0 auto;background-color:#FFF2F8;color:#090;border:3px #090 solid;;text-align:center;font-size:16px;"><img style="margin-right:10px;" src="images/loading.gif">';
            var htmlfoot = '</div>';
            $('.msg_bg').height($(document).height());
            var left = ($(document).width() - 500) / 2;
            $('.sub_err').css({
                'left': left + 'px'
            });
            $('.sub_err').html(htmltop + msg + htmlfoot);
            var scroll_height = $(document).scrollTop();
            $('.sub_err').animate({
                'top': scroll_height + 120
            }, 500);
            msgdsq = setTimeout(function () {
                $('.sub_err').animate({
                    'top': scroll_height + 80
                }, 500);
                setTimeout(function () {
                    $('.msg_bg').remove();
                    $('.sub_err').remove();
                    if (url != '') {
                        location.href = url;
                    }
                }, 800);
            }, "1000");
        };


    </script>


    <title>注册</title>
</head>
<body>
    <form id="form1" runat="server">


        <div class="phone-wrapper" id="phone-wrapper">
            &nbsp;<!--top--><%--<div id="" class="phone-top">
                <header id="commonHead">
                    <div class="category_title">注册</div>
                </header>
            </div>--%>

			<img style="width:100%;height:150px;"  src="images/region.jpg"/>

            <!--body-->
            <div class="personal_form">
                <div class="personal_table_box">
                    <div id="pttip" class="pttip">
                        <div class="main">
                            <i id="tip_icon" class="pttip-icon"></i>
                            <span id="pttip-msg"></span>
                        </div>
                    </div>
                    <table style="width: 100%; border: 0; padding: 0; border-spacing: 0;">
                        <tr>
                            <td class="bgwhite padleft">姓名(会员名)<input type="text" id="name" class="txt" name="name" placeholder="请输入姓名" runat="server"/></td>
                        </tr>
                        <tr style="margin-top: 10px;">
                            <td class="bgwhite padleft">性 别&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          
                    <input class="int_rad" id="Radio2" name="sex1" type="radio" value="1" checked="checked" />男士
                    <input class="int_rad" id="Radio1" name="sex1" type="radio" value="2"/>女士</td>
 
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">生 日

                      <input type="text" name="USER_AGE" id="USER_AGE" readonly="true" class="txt" placeholder="请填写出生日期" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">手机号码<input type="text" id="phone" name="phone" class="txt" placeholder="请输入手机" runat="server"/></td>
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">
                              
                                验证码<input type="text" id="password" name="password" class="txt" placeholder="短信验证码" runat="server" /> <span style="float:right">  <input type="button" id="btn" value="免费获取验证码" onclick="settime(this)" style="color:#000000;border:solid #000000 1.5px;background-color:transparent;" />
</span>
 
                            </td>
                        </tr>
                        <tr>
                            <td ><input name="" type="checkbox"  value="" style="vertical-align:middle; margin-top:0;" /> 
 <input type="button" id="sect" style="border: 0; background: url(); text-decoration: underline; color: #4b8e63;" value="同意会员隐私条例" onclick="none(this)" />
                                
                              </td>  
                         
                        </tr>



                    </table>

                    <div id="huiyuan" class="xieyi" style="display: none">
                        <p>
                            会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例
                        </p>

                        <p>会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例</p>


                        <p>
                           会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例
                        </p>

                        <p>会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例</p>

                        <p>
                           会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例
                        </p>

                        <p>会员隐私条例会员隐私条例会员隐私条例会员隐私条例会员隐私条例</p>
                    </div>

                    <table style="width: 100%; border: 0; padding: 0; border-spacing: 0;">
                        <tr>
                            <td class="noborder tCenter">
                                <asp:Button ID="btnsumbit" runat="server" class="confirm_btn" Text="提交" OnClick="btnsumbit_Click"  />
                            </td>
                        </tr>
                       
                    </table>
                    <div style = "text-align:right;">
                          <input type="button" id="submit_btn" value="绑定/登录会员"style="color:#000000;border:solid #000000 1.5px;background-color:transparent;text-align:right"/>
                    </div>

                </div>
            </div>
        </div>



    </form>
</body>
</html>
