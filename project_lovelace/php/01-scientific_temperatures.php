<?php
/*
 * 11/28/2019
 *
 * https://projectlovelace.net/problems/scientific-temperatures/
 *
 * Write a function fahrenheit_to_celsius(F) that takes an input of Fahrenheit temperature 
 * and converts it to Celsius.
 * C = 5/9 (F - 32)
 */
if (isset($_POST['fahrenheitTemp']) && $_POST['fahrenheitTemp'] != '') {
	$fahrenheitTemp = $_POST['fahrenheitTemp'];
	$celsiusTemp = ($fahrenheitTemp - 32) * (5/9);
}
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Scientific Temperature</title>
    <style>
        #wrapper {
            text-align: center;
        }
    </style>
</head>

<body>
    <div id="wrapper">
        <form action="1-scientific_temperatures.php" method="post">
            Input Fahrenheit temperature: 
            <input type="number" step="0.01" name="fahrenheitTemp" value="<?php if (isset($fahrenheitTemp)) echo $fahrenheitTemp;  ?>" /><br><br>
            <input type="submit" value="Submit" />
        </form>
        <br><br>
        <?php if (isset($celsiusTemp)) echo "Output Celsius Temperature: " . round($celsiusTemp, 4); ?>
    </div>
</body>
</html>