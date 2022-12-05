<?php

	$data = array(
		'id' => 1,
		'head' => 1,	
		'body' => 2,	
		'pant' => 3,	
		'shoe' => 4,	
	);
	
	$post_data = json_encode($data);
	
	$ch = curl_init();
	
	$options = array(
		CURLOPT_URL => 'http://localhost/json/target.php',
		CURLOPT_POST => 1,
		CURLOPT_POSTFIELDS => $post_data,
		CURLOPT_RETURNTRANSFER => 1,
		CURLOPT_HTTPHEADER => array('Content-Type: application/json')
	);
	
	curl_setopt_array($ch, $options);
	
	$result = curl_exec($ch);
	
	curl_close($ch);
	print_r($result);

?>