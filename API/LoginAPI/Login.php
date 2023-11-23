<?php

//MySQL database Connection
$con=mysqli_connect('phpmyadmin.jverrijt.nl','jayv','Woezel-2005!','scannerapp');

//Received JSON into $json variable
$json = file_get_contents('php://input');

//Decoding the received JSON and store into $obj variable.
$obj = json_decode($json,true);

if(isset($obj["username"]) && isset($obj["password"])){

    $uname = mysqli_real_escape_string($con,$obj['username']);
    $pwd = mysqli_real_escape_string($con,$obj['password']);

    //Declare array variable
    $result=[];

    //Select Query
    $sql="SELECT * FROM users WHERE username='{$uname}' and password='{$pwd}' AND role='1'";
    $res=$con->query($sql);

    if($res->num_rows>0){

        $row=$res->fetch_assoc();

        $result['loginStatus']=true;
        $result['message']="Login Successfully";

        $result["userInfo"]=$row;

    }else{

        $result['loginStatus']=false;
        $result['message']="Invalid Login Details";
    }

    // Converting the array into JSON format.
    $json_data=json_encode($result);

    // Echo the $json.
    echo $json_data;
}
?>