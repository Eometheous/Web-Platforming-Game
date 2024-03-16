<script>
	import { onMount } from 'svelte';
	let htmlContent = '';

	async function getGame() {
        try {
            const response = await fetch('http://127.0.0.1:8080/loadGame');
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            htmlContent = await response.text();
            console.log(htmlContent);
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
        }
    }

    onMount(() => {
        getGame();
    });
</script>

<svelte:head>
	<title>Game</title>
</svelte:head>

<div class="renderedHTML">
    {@html htmlContent}
</div>

<style>
	@import 'tailwindcss/base';
	@import 'tailwindcss/components';
	@import 'tailwindcss/utilities';
</style>
