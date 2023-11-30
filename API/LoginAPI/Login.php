<?php
    include 'db.php';

    global $serverurl, $servuser, $servpasswd, $target;

    $con = mysqli_connect($serverurl, $servuser, $servpasswd, $target);
    $json = file_get_contents('php://input');
    $obj = json_decode($json,true);

    if(isset($obj['username']) && isset($obj['password'])){
        $uname = mysqli_real_escape_string($con, $obj['username']);
        $plainpass = mysqli_real_escape_string($con, $obj['password']);

        $result = [];


        // Fetching Hash from DB
        $query = "SELECT password FROM users WHERE username='{$uname}' AND role='1'";
        $run = mysqli_query($con,$query);
        $res = mysqli_fetch_assoc($run);
        $hashresult = $res['password'];
    }


if (password_verify($plainpass,$hashresult)){
    $result['loginStatus'] = true;
    $result['message'] = 'Login Successful';

} else {
    $result["loginStatus"] = false;
    $result["message"] = "Login Failed";
}

    $json_e = json_encode($result);
    echo $json_e;
?>