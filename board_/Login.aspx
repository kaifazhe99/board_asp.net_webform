<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="board_.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
        }

        /* ------------- Login ------------- */

        .login-wrap {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; /* 부모 요소의 높이를 화면 전체 높이로 설정 */
            background-repeat: no-repeat;
            background: linear-gradient(to bottom right, #212529, #f5f5f5);
            background-color: #f5f5f5;
        }

        

        #form1 {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .id-wrap, .pw-wrap {
            position: relative;
            width: 230px;
            height: 50px;
            margin-bottom: 5px;
            text-align: center;
        }



        .loginBtn-wrap {
            width: 230px;
            height: 44px;
        }

        #email-input, #pw-input {
            display: block;
            font-size: 15px;
            width: 100%;
            height: 100%;
            padding: 15px 5px 0px 8px;
            margin-bottom: 5px;
            color: #444444;
            border: 1px solid #0d47a1;
            border-radius: 3px;
            outline: 0;
        }

        #loginBtn {
            width: 100%;
            height: 100%;
            font-size: 17px;
            margin-top: 5px;
            color: #fff;
            background-color: #212529;
            border: none;
            border-radius: 3px;
            outline: 0;
            cursor: pointer;
            transition: 0.3s ease;
        }

            #loginBtn:hover {
                background-color: #bbdefb;
            }

        .phTxt_email, .phTxt_pw {
            position: absolute;
            top: 50%;
            left: 10px;
            transform: translate(0, -50%);
            font-size: 16px;
            color: #444444;
            transition: 0.35s ease;
            vertical-align: top;
            user-select: none;
            z-index: 10;
            cursor: text;
        }

        #email-input:focus ~ .phTxt_email {
            font-size: 9px;
            top: 12px;
            left: 7px;
        }

        #pw-input:focus ~ .phTxt_pw {
            font-size: 9px;
            top: 12px;
            left: 7px;
        }

        .square{
            border:3px;
        }
    </style>
</head>
<body>

    <div class="login-wrap">
        <form id="form1" runat="server">



            <div class="square">
                <div class="id-wrap">

                    <label>아이디</label>
                    <asp:TextBox runat="server" ID="ID"></asp:TextBox>
                </div>
                <div class="pw-wrap">
                    <label>비밀번호</label>
                    <asp:TextBox runat="server" ID="PW"
                        TextMode="Password"></asp:TextBox>

                </div>
                <div class="loginBtn-wrap">
                    <asp:Button runat="server" ID="loginBtn" Text="로그인" OnClick="btnLogin_Click"></asp:Button>
                </div>
            </div>




        </form>
    </div>




</body>
</html>
