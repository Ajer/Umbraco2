
app.controller('ctrlmember', ['$scope', '$http', 'operations', function($scope, $http, operations) {

        $scope.userAuthentication = 'Fail';

        $scope.login = function (Member) {

        $('#retrievingDataModal').modal('show');

        var error = '';

        if ($('#txtEmail').val() == '') {
            error += 'Email is reqiured, ';
        }
        if ($('#txtPassword').val() == '') {
            error += 'Password is reqiured';
        }

        if ($('#txtEmail').val() != '' && $('#txtPassword').val() != '') {

            operations.Read('/api//Login', { email: Member.Email, password: Member.Password }).success(function (data) {

                $scope.userAuthentication = 'Pass';
                $scope.userEmail = $('#txtEmail').val();
                $('#divLayoutMenu').show();
                $('#txtEmail').val('');
                $('#txtPassword').val('');
                $('#retrievingDataModal').modal('hide');


            }).error(function () {

                $scope.userAuthentication = 'Fail';
                $('#divLayoutMenu').hide();

                $('#messageModal').find('#messageModalHeading').empty();
                $('#messageModal').find('#messageModalText').empty();


                $('#messageModal').find('#messageModalHeading').append('Infromation');
                $('#messageModal').find('#messageModalText').text('Check your credentials and try again. If you are not a registered user please register first');
                $('#messageModal').modal('show');
                $('#retrievingDataModal').modal('hide');

            });
        }
        else {
            $('#messageModal').find('#messageModalHeading').empty();
            $('#messageModal').find('#messageModalText').empty();

            $('#messageModal').find('#messageModalHeading').append('Error');
            $('#messageModal').find('#messageModalText').text(error);
            $('#messageModal').modal('show');
            $('#retrievingDataModal').modal('hide');
        }
    }
   
}]);

// --------------- REGISTER NEW MEMEBER  -------------------
$scope.RegisterMember = function (NewMember) {

    var error = '';

    if (NewMember.Email == '') {
        error += 'Email is reqiured, ';
    }
    if (NewMember.Password == '') {
        error += 'Password is reqiured';
    }


    if (NewMember.Email != '' && error == '') {


        var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;

        //EMAIL VALIDATION
        if (filter.test(NewMember.Email)) {


            NewMember.Email = CryptoJS.SHA1(NewMember.Email);
            NewMember.Password = CryptoJS.SHA1(NewMember.Password);

            myOperations.Create('/api/Member/RegisterNewMember', NewMember).success(function () {

                $('#messageModal').modal('hide');

            }).error(function () {


            });
        }
        else {

            $('#messageModal').find('#messageModalHeading').empty();
            $('#messageModal').find('#messageModalText').empty();


            $('#messageModal').find('#messageModalHeading').append('Error');
            $('#messageModal').find('#messageModalText').text('Invalid email !!!');
            $('#messageModal').modal('show');
        }

    }
    else {

        $('#messageModal').find('#messageModalHeading').empty();
        $('#messageModal').find('#messageModalText').empty();

        $('#messageModal').find('#messageModalHeading').append('Error');
        $('#messageModal').find('#messageModalText').text(error);
        $('#messageModal').modal('show');
    }

}


//REDIRECT PAGE
$scope.redirectPage = function (id) {

    if ($scope.userAuthentication == 'Pass') {

        $('.myPage').hide();
        $('#' + id).show();
        $('#' + id).find('#div' + id + 'Home').show();

    }
    else {

        $('#messageModal').find('#messageModalHeading').empty();
        $('#messageModal').find('#messageModalText').empty();

        $('#messageModal').find('#messageModalHeading').append('Information');
        $('#messageModal').find('#messageModalText').text('You are not authorized!!!');
        $('#messageModal').modal('show');
    }
}