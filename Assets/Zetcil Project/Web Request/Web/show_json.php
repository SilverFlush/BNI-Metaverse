<?php

	$form_data = file_get_contents('php://input');
	$final_data = json_decode($form_data);
	print_r($final_data);
	
?>