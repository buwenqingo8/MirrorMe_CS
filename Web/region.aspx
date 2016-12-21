<%@ Page Language="C#" AutoEventWireup="true" CodeFile="region.aspx.cs" Inherits="region" %>


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

            //注册
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

        function sky(msg) {
          //  localStorage.removeItem("c");
            localStorage.setItem('phone', $('#phone').val())
            //  alert($('#phone').val());
            window.location.href = "index.aspx";


        };

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
            $('body').append('<div class="sub_err" style="position:absolute;top:60px;width:300px;z-index:999999;"></div>');
            var errhtml = '<div  class="bac" style="padding:8px 0px;border:1px solid #ff0000;width:100%;margin:0 auto;background-color:#fff;color:#B90802;border:3px #ff0000 solid;text-align:center;font-size:16px;font-family:微软雅黑;"><img style="margin-right:10px;" src="images/error.png">';
            var errhtmlfoot = '</div>';
            $('.msg_bg').height($(document).height());
            $('.sub_err').html(errhtml + msg + errhtmlfoot);
            var left = ($(document).width() - 300) / 2;
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


        $(function () {
            $("#btnGetYzm").bind("click", function () {
                if (mobileResult == true) {

                    /****************************发送验证码到手机************************/
                    $.ajax({
                        type: "POST",
                        //  url: "../User/Ajax/SendCheckcode.ashx?r=" + Math.random(),

                        url: "login.aspx/BB",

                        data: { ajaxdata: $("#txtMobile").val() },
                        async: false,
                        success: function (msg) {
                            if (msg != 0) {
                                show_err_msg(msg);
                                result = false;
                            }
                            else {

                                result = true;
                            }
                        },
                        error: function (xhr) {
                            show_err_msg("Error:" + xhr.status + " " + xhr.statusText);


                            result = false;
                        }
                    });
                    /****************************end************************/
                    count = 60;
                    GetYzm();
                    return true;
                }
                else {
                    //手机号验证
                    VerifyCheck($("#phone"), $("#txtMobile"), "请输入正确的手机号！", /^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/, "手机号不合法！", "login.aspx/BB");
                    //return false;

                    count = 60;
                    GetYzm();
                }
            });
        })

        var result = false;
        var mobileResult = false;
        var retMobile = false; //手机号验证是否通过
        var retChkCode = false; //填写的手机接收的验证码是否通过
        //表单元素验证,txt:要验证的文本值；div:文本验证信息层；divmsg：文本验证消息；
        //reg：正则式；regmsg：正则式验证消息；ajaxurl：文本值有效性请求验证页面；divhtml：验证返回消息
        function VerifyCheck(txt, div, divmsg, reg, regmsg, ajaxurl) {
            if ($.trim(txt.val()) == "") {//判断文本框是否填写
                show_err_msg(divmsg);

                return false;
            }
            else {
                if (reg != null && !reg.test(txt.val())) {//判断是否输入合法字符
                    show_err_msg(regmsg);

                    return false;
                }
                else {
                    /****************************检查文本输入值是否可用************************/
                    $.ajax({
                        type: "POST",
                        //url: ajaxurl,
                        url: "login.aspx/BB",

                        data: "{'phone':'" + txt.val() + "'}",
                        async: false,
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg != 0) {

                                result = false;
                                //  result = true;
                            }
                            else {

                                if (divmsg == "请输入正确的手机号！") {
                                    mobileResult = true;
                                }


                                result = true;
                            }
                        },
                        error: function (xhr) {
                            show_err_msg("Error:" + xhr.status + " " + xhr.statusText);

                            result = false;
                        }
                    });
                    return result;
                    /****************************end************************/
                }
            }
        }

        //设置发送验证码的按钮的倒计时效果
        var count = 60;
        function GetYzm() {
            $("#btnGetYzm").attr("disabled", "disabled");
            $("#btnGetYzm").val(count + "秒之后重发")
            count--;
            if (count > 0) {
                setTimeout(GetYzm, 1000);
            }
            else {
                $("#btnGetYzm").val("获取验证码");
                $("#btnGetYzm").attr("disabled", false);
            }
            return result;
        }

    </script>

    <style>
        .link-area {
            display: block;
            margin-top: 10px;
            text-align: center;
        }
    </style>
    <title>注册</title>
</head>
<body style="font-size:14px">
    <form id="form1" runat="server">


        <div class="phone-wrapper" id="phone-wrapper">
            &nbsp;<!--top--><%--<div id="" class="phone-top">
                <header id="commonHead">
                    <div class="category_title">注册</div>
                </header>
            </div>--%>

            <img style="width: 100%; height: 150px;" src="images/region.jpg" />

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
                            <td class="bgwhite padleft">姓名(会员名)<input type="text" id="name" class="txt" name="name" placeholder="请输入姓名"   runat="server" style="width:60%" /></td>
                        </tr>
                       <%-- <tr style="margin-top: 10px;">
                            <td class="bgwhite padleft">性 别&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          
                    <input class="int_rad" id="Radio2" name="sex1" type="radio" value="0" />男士
                    <input class="int_rad" id="Radio1" name="sex1" type="radio" value="1"  checked="checked" />女士</td>

                        </tr>--%>
                        <tr>
                            <td class="bgwhite padleft">生 日

                      <input type="text" name="USER_AGE" id="USER_AGE" readonly="true" class="txt" placeholder="请填写出生日期" runat="server" style="width:60%"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">
                            所属门店:    <asp:DropDownList ID="ddlMD" runat="server">
                                    <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="2003">杭州工联旗舰店</asp:ListItem>
                                    <asp:ListItem Value="2001">杭州湖滨银泰店</asp:ListItem>
                                    <asp:ListItem Value="2002">杭州下沙福雷德</asp:ListItem>
                                <asp:ListItem Value="2004">杭州嘉里中心店</asp:ListItem>
                                 <asp:ListItem Value="2006">绍兴柯桥万达店</asp:ListItem>
                                 <asp:ListItem Value="2009">丹阳八佰伴店</asp:ListItem>
                                <asp:ListItem Value="2010">台州银泰城店</asp:ListItem>
								<asp:ListItem Value="1000001">宿迁宝龙城市广场店</asp:ListItem>
                                    
                                </asp:DropDownList>
                                <%--<select id="selMD" runat="server" title="所属门店">
                                <option  value="2003">工联旗舰店</option>
                                <option value="2001">湖滨银泰店</option>
                                <option value="2002">下沙福雷德</option>
                                                                    </select>--%>
                            </td>
                        </tr>

                        <tr>
                            <td class="bgwhite padleft">手机号码<input type="text" id="phone" name="phone" class="txt" placeholder="请输入手机" runat="server" style="width:60%"/></td>
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">验证码<input type="text" id="txtChkCode" name="password" class="txt" placeholder="短信验证码" runat="server" />
                                <span style="float: right">
                                    <input type="button" id="btnGetYzm" value="免费获取验证码"  style="color: #000000; border: solid #000000 1.5px; background-color: transparent;"  runat="server"/>
                                </span>

                            </td>
                        </tr>
                        <tr>
                            <td class="bgwhite padleft">
                                <input name="chkYes" type="checkbox" value="" style="vertical-align: middle; margin-top: 0;" id="chkYes" runat="server"/>
                                <input type="button" id="sect" style="border: 0; background: url(); text-decoration: underline; color: #4b8e63;" value="同意会员隐私条例" onclick="none(this)" />

                            </td>

                        </tr>



                    </table>

                    <div id="huiyuan" class="xieyi" style="display: none">
                        <p>
                            第一条 目的
制定本服务使用条款（以下简称“本条款”）的目的在于规范及阐明用户在注册成为 “HAPSODE悦芙媞”会员的时候，会员所享有的权利及相关服务，所承担的义务及责任的明细。尊重并保护所有使用HAPSODE悦芙媞会员平台服务用户的个人隐私权;给会员提供更准确、更有个性化的服务。（对于通过计算机通讯、移动通讯等电子设备进行的注册访问等，在不与其目的和性质相冲突的前提下同样适用本条款内容）   
                        </p>

                        <p>
                            第二条 本条款的说明、修改
HAPSODE悦芙媞在不违反现行有效的法律法规及规范性文件的前提下，可在合理范围内根据需要不时制订、修改本条款或各类规则，并以网站公示的方式进行公告，不再单独通知用户。修订后的条款或将来可能发布或更新的各类规则一经在网站公布后，立即自动生效。如用户不同意相关修订，应当立即停止使用网站服务。用户继续使用网站服务，即表示用户接受经修订的条款或规则。
                        </p>
                        <p>
                            第三条 服务的中断和终止
1.	用户向HAPSODE悦芙媞提出注销账户申请，经HAPSODE悦芙媞审核同意后，由HAPSODE悦芙媞注销该用户账户，本条款即告终止。但在注销该用户账户后，网站仍有权：
a.保留该用户的注册信息及过往的全部交易行为记录；
b.如用户在账户注销前在使用过程中存在违法行为或违反本条款的行为，网站仍可行使本条款所规定的权利。
2.	在下列情况下，HAPSODE悦芙媞可以通过注销用户账户的方式单方解除本条款：
a.在用户违反本条款相关规定时，HAPSODE悦芙媞有权暂停或终止向该用户提供服务。如该用户在HAPSODE悦芙媞暂停或终止提供服务后，再一次直接或间接或以他人名义注册为HAPSODE悦芙媞用户的，则HAPSODE悦芙媞有权再次暂停或终止向该用户提供服务；
b. 一经发现用户注册信息中的内容是虚假的，HAPSODE悦芙媞即有权终止向该用户提供服务；
c.本条款修改或更新时，如用户表示不愿接受新的服务协议的，网站有权终止向该用户提供服务；
d. 因从其他网站服务而由会员承担的债务到期后未及时还清的；
e.出现妨碍他人使用网站服务，或盗取网站信息等危及网站的正常运营行为的；
f.故意阻碍服务或网站运营的；
g. HAPSODE悦芙媞认为需终止提供服务的其他情况。
3.  HAPSODE悦芙媞官网、会员平台网站等因计算机等电子通讯设备的维护检查、交换、通信故障等原因需要暂停服务的，通知该等事项后可暂停服务。
4.	网站对因前款服务暂停导致的用户直接损失进行赔偿，但网站不存在故意或过失的情况下不承担责任。
5.	应经营类别的转换、取消经营，合并等原因无法提供服务的，网站应通知用户并根据原有条款约定补偿用户。但网站未事前约定补偿标准等事项的，HAPSODE悦芙媞可向用户以网站积分、信用或有价值的产品提供兑换补偿。
                        </p>

                        <p>
                            第四条 会员注册及个人信息保护
（1）	用户应确认本条款内容，按照注册提供的样式填写会员信息，并通过接受本条款内容方式注册经HAPSODE悦芙媞审核通过后成为会员。用户同意接受本条款的，本条款将适用HAPSODE悦芙媞与用户之间发生的所有交易
（2）	用户承诺按照申请注册样式填写的用户所有信息均为符合事实的信息。未填写实际信息的用户，如经发现，HAPSODE悦芙媞有权注销其会员账户并单方解除本条款。
（3）	会员在注册会员时提供的信息发生变化的，应立即以相应的方式通知HAPSODE悦芙媞。如会员未通知或未及时通知该等变更事项导致的损失，HAPSODE悦芙媞不负任何赔偿责任。
（4）	用户在注册成为HAPSODE悦芙媞会员的时候提供的信息未经会员同意，HAPSODE悦芙媞不会将会员信息提供服务以外的其他用途或向第三方提供。同时，HAPSODE悦芙媞会不时更新本隐私权政策，完善会员体系。您在同意HAPSODE悦芙媞服务协议之时，即视为您已经同意本隐私权政策全部内容。本隐私权政策属于HAPSODE悦芙媞服务协议不可分割的一部分。
                        </p>

                        <p>
                            【适用范围】
a)	在您注册或激活可以登录HAPSODE悦芙媞会员平台的账户时，您在HAPSODE悦芙媞会员平台提供的个人注册信息。
b)	在您使用HAPSODE悦芙媞会员平台服务，或访问HAPSODE悦芙媞会员平台网页时，HAPSODE悦芙媞会员自动接收并记录的您在浏览器和计算机上的信息，包括但不限于您的IP地址、浏览器的类型、使用的语言、访问日期和时间、软硬件特征信息及您需求的网页记录等数据。
c)	HAPSODE悦芙媞通过合法途径从商业伙伴处取得的用户个人数据。
                        </p>

                        <p>
                            【信息使用】
a)	HAPSODE悦芙媞不会向第三方(HAPSODE悦芙媞关联公司或因适用本条款产生的可信的业务合作伙伴除外)提供、分享您的个人信息，除非事先得到您的许可，或该第三方和HAPSODE悦芙媞单独或共同为您提供服务，且在该服务结束后，其将被禁止访问包括其以前能够访问的所有这些资料。
b)	HAPSODE悦芙媞亦不允许任何第三方以任何手段收集、编辑、出售或者无偿传播您的个人信息。任何HAPSODE悦芙媞会员平台用户如从事上述活动，一经发现，HAPSODE悦芙媞有权立即终止与该用户的服务协议。
c)	为服务用户的目的，HAPSODE悦芙媞或其关联公司可能通过使用您的个人信息，向您提供您可能感兴趣的信息，包括但不限于向您发出产品和服务信息，或通过系统向您展示个性化的第三方推广信息，或者与HAPSODE悦芙媞合作伙伴共享信息以便他们向您发送有关其产品和服务的信息。
                        </p>
                        <p>
                            【信息披露】
在如下情况，HAPSODE悦芙媞将依据您的个人意愿或法律的规定全部或部分的披露您的个人信息：
a)	经您事先同意，向第三方披露；
b)	为统计客户消费情况等之所需，按照无法分辨特定用户的方式提供的；
c)	为产品的交易结算货款之所需；
d)	为提供您所要求的产品和服务，而必须和第三方分享您的个人信息；
e)	为防止盗用与用户本人确认之所需；
f)	因法律法规相关规定无法避免的情况。
g)	其它HAPSODE悦芙媞根据法律、法规或者网站政策认为合适的披露
                        </p>
                        <p>
                            【存储和交换】
HAPSODE悦芙媞收集的有关您的信息和资料将保存在HAPSODE悦芙媞或关联公司的服务器上，这些信息和资料可能传送至您所在地区或HAPSODE悦芙媞收集信息和资料所在地被访问、存储和展示。
                        </p>
                        <p>【信息安全】
a)	您的账户均有安全保护功能，请妥善保管您的账户及密码信息。HAPSODE悦芙媞将通过向其它服务器备份、对用户密码进行加密等安全措施确保您的信息不丢失，不被滥用和变造。尽管有前述安全措施，但同时也请您注意在信息网络上不存在“完善的安全措施”。
b)	在使用HAPSODE悦芙媞会员平台服务进行网上交易时，您不可避免的要向交易对方或潜在的交易对方披露自己的个人信息，如联络方式或者邮政地址。请您妥善保护自己的个人信息，仅在必要的情形下向他人提供。如您发现自己的个人信息泄密，尤其是你的账户及密码发生泄露，请您立即联络HAPSODE悦芙媞客服，以便HAPSODE悦芙媞采取相应措施。
</p>
                        <p>第五条 会员享有的权利及服务
（1）	会员享有HAPSODE悦芙媞会员专属的会员礼遇、活动及积分政策
（2）	会员可以在HAPSODE悦芙媞官网或认证微信公众号知晓最新产品信息及产品活动。
</p>
                        <p>第六条 会员承担的义务与明细
（1）	账户和密码的管理责任在于用户。
（2）	会员不得将账户或密码提供第三方使用。
（3）	用户不得行使下列行为，如用户发生下述行为，HAPSODE悦芙媞有权根据本条款以及相关法律法规规定采取必要措施。
a. 申请注册或变更信息时，提供虚假信息；
b. 盗用他人信息；
c. 随意更改网站提示的信息；
d. 使用网站指定信息之外的信息（例如软件等）用于发送或发布；
e. 侵害网站以及其他第三方著作权等知识产权的；
f. 侵害网站以及其他第三方名誉或妨碍正常经营的；
g. 谎称为网站的运营者、职员或关联人员的；
h. 未经网站同意收集或储存其他用户个人信息的；
i. 在网站发布歪曲、暴利信息、视频、音频等其他违反公序良俗的信息的。
（4）	用户应遵守本条款规定的事项及其他HAPSODE悦芙媞官方规定的统一适用的规定、公告等内容 
以及相关法律法规。
（5）	用户在HAPSODE悦芙媞官网，在未经网站的事先书面允许，禁止用户在网站上发布任何形式的
       广告，不得从事利用网站信息的营业活动，对该等营业活动的后果网站不承担责任。且用户因该等营业活动导致网站损失的，用户应承担赔偿责任，网站对该等用户可采取限制使用服务等合法措施。
</p>
                        <p>第七条 以上会员注册条例的最终解释权归悦芙媞（杭州）化妆品有限公司所有。
</p>
                        <p>附则 本条款自 2016   年6  月 19 日开始实施并生效。</p>
                    </div>

                    <table style="width: 100%; border: 0; padding: 0; border-spacing: 0;">
                        <tr>
                            <td class="noborder tCenter">
                                <asp:Button ID="btnsumbit" runat="server" class="confirm_btn" Text="提交" OnClick="btnsumbit_Click" Font-Size="16px" />
                            </td>
                        </tr>

                    </table>


                    <div class="link-area">
                        <a id='reg' style="color: #4b8e63; font-size: 16px;" href="login.aspx">登录(绑定)会员</a>
                    </div>


                </div>
            </div>
        </div>



    </form>
</body>
</html>
