<?php
    $con=mysqli_connect('phpmyadmin.jverrijt.nl','jayv','Woezel-2005!','scannerapp');
    $json = file_get_contents('php://input');
    $obj = json_decode($json,true);
    
    if(isset($obj["ean"])) {
        $ean = mysqli_real_escape_string($con,$obj['ean']);
        $result=[];
        $sql="SELECT * FROM products WHERE ean='{$ean}'";
        $res=$con->query($sql);
        if($res->num_rows>0){
            $row=$res->fetch_assoc();
            $result['productInfo']=$row;
        }else{
            $result['productInfo']=false;
        }
        $json_data=json_encode($result);
        echo $json_data;
    }