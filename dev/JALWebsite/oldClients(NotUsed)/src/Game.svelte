<script lang="js">
	import { onMount } from 'svelte';
	import NavBar from './Components/NavBar.svelte';

	let stringTest = "not pulled from backend yet"
	
	async function getBackendTest() {
		try {
            const response = await fetch('http://127.0.0.1:8080/getBackendTest');
			const data = await response.json();
			stringTest = data.stringTest;
			console.log(stringTest);
		} catch (error) {
			console.error('Error fetching data:', error);
		}
	}

	getBackendTest();
</script>

<style>
</style>

<html lang="ts">
	<NavBar/>
	<h1>{stringTest}</h1>
</html>