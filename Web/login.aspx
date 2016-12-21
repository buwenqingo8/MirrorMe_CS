<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    	<head runat="server">
		
               <meta content="text/html; charset=gbk" http-equiv="Content-Type" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta content="登录" name="description" />

    <meta content="telephone=no" name="format-detection" />
		<title>登录</title>
             <link href="css/touch.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/normalize3.0.2.min.css" />
    <link rel="stylesheet" href="css/style.css?v=7" />
    <link href="css/mobiscroll.css" rel="stylesheet" />
		<link href="css/mui.min.css" rel="stylesheet" />
		<link href="css/login.css" rel="stylesheet" />
            <script src="js/mui.min.js"></script>
		<script src="js/mui.enterfocus.js"></script>
            <script src="js/jquery.min.js"></script>
		<script src="js/app.js"></script>
		<style>
			.area {
				margin: 20px auto 0px auto;
			}
			
			.mui-input-group {
				
			}
			
			.mui-input-group:first-child {
				margin-top: 20px;
			}
			
			.mui-input-group label {
				
                font-size:14px;
			}
			
			.mui-input-row label~input,
			.mui-input-row label~select,
			.mui-input-row label~textarea {
				
                 font-size:14px;
                 height: 38px;
                 color: #666;
			}
			
			.mui-checkbox input[type=checkbox],
			.mui-radio input[type=radio] {
				top: 6px;
			}
			
			.mui-content-padded {
				margin-top: 25px;
			}
			
			.mui-btn {
				padding: 10px;
			}
			
			.link-area {
				display: block;
				margin-top: 25px;
				text-align: center;
			}
			
			.spliter {
				color: #bbb;
				padding: 0px 8px;
			}
			
			.oauth-area {
				position: absolute;
				bottom: 20px;
				left: 0px;
				text-align: center;
				width: 100%;
				padding: 0px;
				margin: 0px;
			}
			
			.oauth-area .oauth-btn {
				display: inline-block;
				width: 50px;
				height: 50px;
				background-size: 30px 30px;
				background-position: center center;
				background-repeat: no-repeat;
				margin: 0px 20px;
				/*-webkit-filter: grayscale(100%); */
				border: solid 1px #ddd;
				border-radius: 25px;
			}
			
			.oauth-area .oauth-btn:active {
				border: solid 1px #aaa;
			}
			
			.oauth-area .oauth-btn.disabled {
				background-color: #ddd;
			}
		</style>
         	
		<script type="text/javascript">
		    (function ($, doc) {
		        $.init({
		            statusBarBackground: '#f7f7f7'
		        });
		        $.plusReady(function () {
		            plus.screen.lockOrientation("portrait-primary");
		            var settings = app.getSettings();
		            var state = app.getState();
		            var mainPage = $.preload({
		                "id": 'main',
		                "url": 'main.html'
		            });
		            var toMain = function () {
		                $.fire(mainPage, 'show', null);
		                setTimeout(function () {
		                    $.openWindow({
		                        id: 'main',
		                        show: {
		                            aniShow: 'pop-in'
		                        },
		                        waiting: {
		                            autoShow: false
		                        }
		                    });
		                }, 0);
		            };
		            //检查 "登录状态/锁屏状态" 开始
		            if (settings.autoLogin && state.token && settings.gestures) {
		                $.openWindow({
		                    url: 'unlock.html',
		                    id: 'unlock',
		                    show: {
		                        aniShow: 'pop-in'
		                    },
		                    waiting: {
		                        autoShow: false
		                    }
		                });
		            } else if (settings.autoLogin && state.token) {
		                toMain();
		            } else {
		                app.setState(null);
		                //第三方登录
		                var authBtns = ['qihoo', 'weixin', 'sinaweibo', 'qq']; //配置业务支持的第三方登录
		                var auths = {};
		                var oauthArea = doc.querySelector('.oauth-area');
		                plus.oauth.getServices(function (services) {
		                    for (var i in services) {
		                        var service = services[i];
		                        auths[service.id] = service;
		                        if (~authBtns.indexOf(service.id)) {
		                            var isInstalled = app.isInstalled(service.id);
		                            var btn = document.createElement('div');
		                            //如果微信未安装，则为不启用状态
		                            btn.setAttribute('class', 'oauth-btn' + (!isInstalled && service.id === 'weixin' ? (' disabled') : ''));
		                            btn.authId = service.id;
		                            btn.style.backgroundImage = 'url("images/' + service.id + '.png")'
		                            oauthArea.appendChild(btn);
		                        }
		                    }
		                    $(oauthArea).on('tap', '.oauth-btn', function () {
		                        if (this.classList.contains('disabled')) {
		                            plus.nativeUI.toast('您尚未安装微信客户端');
		                            return;
		                        }
		                        var auth = auths[this.authId];
		                        var waiting = plus.nativeUI.showWaiting();
		                        auth.login(function () {
		                            waiting.close();
		                            plus.nativeUI.toast("登录认证成功");
		                            auth.getUserInfo(function () {
		                                plus.nativeUI.toast("获取用户信息成功");
		                                var name = auth.userInfo.nickname || auth.userInfo.name;
		                                app.createState(name, function () {
		                                    toMain();
		                                });
		                            }, function (e) {
		                                plus.nativeUI.toast("获取用户信息失败：" + e.message);
		                            });
		                        }, function (e) {
		                            waiting.close();
		                            plus.nativeUI.toast("登录认证失败：" + e.message);
		                        });
		                    });
		                }, function (e) {
		                    oauthArea.style.display = 'none';
		                    plus.nativeUI.toast("获取登录认证失败：" + e.message);
		                });
		            }
		            // close splash
		            setTimeout(function () {
		                //关闭 splash
		                plus.navigator.closeSplashscreen();
		            }, 600);
		            //检查 "登录状态/锁屏状态" 结束
		            var loginButton = doc.getElementById('login');
		            var accountBox = doc.getElementById('account');
		            var passwordBox = doc.getElementById('password');
		            var autoLoginButton = doc.getElementById("autoLogin");
		            var regButton = doc.getElementById('reg');
		            var forgetButton = doc.getElementById('forgetPassword');
		            loginButton.addEventListener('tap', function (event) {
		                var loginInfo = {
		                    account: accountBox.value,
		                    password: passwordBox.value
		                };
		                app.login(loginInfo, function (err) {
		                    if (err) {
		                        plus.nativeUI.toast(err);
		                        return;
		                    }
		                    toMain();
		                });
		            });
		            $.enterfocus('#login-form input', function () {
		                $.trigger(loginButton, 'tap');
		            });
		            autoLoginButton.classList[settings.autoLogin ? 'add' : 'remove']('mui-active')
		            autoLoginButton.addEventListener('toggle', function (event) {
		                setTimeout(function () {
		                    var isActive = event.detail.isActive;
		                    settings.autoLogin = isActive;
		                    app.setSettings(settings);
		                }, 50);
		            }, false);
		            regButton.addEventListener('tap', function (event) {
		                $.openWindow({
		                    url: 'reg.html',
		                    id: 'reg',
		                    preload: true,
		                    show: {
		                        aniShow: 'pop-in'
		                    },
		                    styles: {
		                        popGesture: 'hide'
		                    },
		                    waiting: {
		                        autoShow: false
		                    }
		                });
		            }, false);
		            forgetButton.addEventListener('tap', function (event) {
		                $.openWindow({
		                    url: 'forget_password.html',
		                    id: 'forget_password',
		                    preload: true,
		                    show: {
		                        aniShow: 'pop-in'
		                    },
		                    styles: {
		                        popGesture: 'hide'
		                    },
		                    waiting: {
		                        autoShow: false
		                    }
		                });
		            }, false);
		            //
		            window.addEventListener('resize', function () {
		                oauthArea.style.display = document.body.clientHeight > 400 ? 'block' : 'none';
		            }, false);
		            //
		            var backButtonPress = 0;
		            $.back = function (event) {
		                backButtonPress++;
		                if (backButtonPress > 1) {
		                    plus.runtime.quit();
		                } else {
		                    plus.nativeUI.toast('再按一次退出应用');
		                }
		                setTimeout(function () {
		                    backButtonPress = 0;
		                }, 1000);
		                return false;
		            };
		        });
		    }(mui, document));

		    var msgdsq;
		    function show_err_msg(msg) {
		        $('.msg_bg').html('');
		        clearTimeout(msgdsq);
		        $('body').append('<div class="sub_err" style="position:absolute;top:60px;left:0;width:300px;z-index:999999;"></div>');
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

		    function sky(msg) {
		        localStorage.setItem('phone', $('#account').val())
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
		                VerifyCheck($("#account"), $("#txtMobile"), "请输入正确的手机号！", /^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/, "手机号不合法！", "login.aspx/BB");
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


	</head>


	<body>
		
		
		
		<div class="mui-content" >
            <img style="width:100%;height:150px;"  src="images/login.jpg"/>
			<form id='loginform' class="mui-input-group"  runat="server">
				<div class="mui-input-row">
					<label style="width:90px;float:left">手机号码</label>
					<input id='account' type="text" class="mui-input-clear mui-input" placeholder="请输入手机号码"  runat="server" style="float:left"/>
				</div>
				<div class="mui-input-row">
					<label style="width:90px;float:left">验证码</label>
					<input id='txtChkCode' type="text" class="txt" placeholder="请输入验证码" style="width:100px ;float:left" runat="server"/>

                     <input type="button" id="btnGetYzm" value="免费获取验证码" style="color: #000000; border: solid #000000 1.5px; background-color: transparent;float:right;width:86px;font-size:12px;height:30px;vertical-align:middle;margin-top:7px;"  runat="server" />
				</div>
			<%--<div class="mui-input-row">
               &nbsp;&nbsp;
                <br />
                如果一段时间没有收到，请&nbsp;
                            <a id="aGetChkCodeAgain" style="cursor: pointer;" class="a1">重新获取</a>
               </div>--%>

			<%--<form class="mui-input-group">
				<ul class="mui-table-view mui-table-view-chevron">
					<li class="mui-table-view-cell">
						自动登录
						<div id="autoLogin" class="mui-switch">
							<div class="mui-switch-handle"></div>
						</div>
					</li>
				</ul>
			</form>--%>
			<div class="mui-content-padded">
               

                  <asp:Button ID="btnlogin" runat="server" class="mui-btn mui-btn-block mui-btn-primary" Text="登录" OnClick="btnlogin_Click" style="background-color:black; font-size:16px;"/>
                
			
				<div class="link-area" > <a id='reg' style="color: #4b8e63; font-size:16px;" href="region.aspx">&nbsp;&nbsp;&nbsp;注册账号</a> <span class="spliter"/>
				</div>
			</div>
			<div class="mui-content-padded oauth-area">

			</div>
                </form>
		</div>
		</body>

</html>
