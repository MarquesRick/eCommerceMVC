window.onload = function () {

    $("#btnLogin").click(function () {
        Login();
    });

    $("#btnRecuperarSenha").click(function () {
        ResetSenha();
    });

    $("#btnCadastrarUsuario").click(function () {
        CadastrarUsuario();
    });
    
    $('#resetPassword').on('shown.bs.modal', function () {
        $('#resetSenhaResult').text("");
        $('#txtEmailResetSenha').val("");
        $('#btnRecuperarSenha').show();
    });
    
    $('#createAcount').on('shown.bs.modal', function () {
        $('#createAcountResult').text("");
        $('#txtNomeUsuario').val("");
        $('#txtEmailUsuario').val("");
        $('#txtIdadeUsuario').val("");
        $('#btnCadastrarUsuario').show();
    });
    
};

function Login() {

    var login = $('#txtLogin').val();
    var password = $('#txtPassword').val();

    $.ajax
        ({
            type: 'POST',
            datatype: 'jsonp',
            cache: false,
            crossDomain: true,
            url: "Login",
            data: { email: login, password: password },
            success: function (result) {
                if (result.retorno.includes("Index")) {
                    window.location.href = result.retorno;
                } else {
                    alert(result.retorno);
                }
            },
            fail : function( jqXHR, textStatus ) {
              alert( "Request failed: " + textStatus );
            }
        });
}

function ResetSenha() {

    $('#resetSenhaResult').text("");

    var login = $('#txtEmailResetSenha').val();

    $.ajax
        ({
            type: 'POST',
            datatype: 'jsonp',
            cache: false,
            crossDomain: true,
            url: "ResetPassword",
            data: { email: login },
            success: function (result) {
                $('#resetSenhaResult').text(result.retorno);
                $('#btnRecuperarSenha').hide();
            },
            fail: function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            }

        });
}

function CadastrarUsuario() {

    var nome = $('#txtNomeUsuario').val();
    var email = $('#txtEmailUsuario').val();
    var idade = $('#txtIdadeUsuario').val();

    $.ajax
        ({
            type: 'POST',
            datatype: 'jsonp',
            cache: false,
            crossDomain: true,
            url: "CreateAcount",
            data: { nome_user: nome, email: email, idade: idade },
            success: function (result) {
                $('#createAcountResult').text(result.retorno);
                $('#btnCadastrarUsuario').hide();
            },
            fail: function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            }
        });
}

