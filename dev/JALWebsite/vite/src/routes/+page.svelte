<svelte:head>
	<title>Game</title>
</svelte:head>

<div class="iframe-container">
    <!-- svelte-ignore a11y-missing-attribute -->
    <iframe frameborder="0" src="https://itch.io/embed-upload/9952218?color=333333" allowfullscreen="" width="1120" height="690">
        <a href="https://byuntaeyeon02.itch.io/jal">Play Jump And Launch on itch.io</a>
    </iframe>
</div>

<style>
	@import 'tailwindcss/base';
	@import 'tailwindcss/components';
	@import 'tailwindcss/utilities';

    .iframe-container {
        padding-top: 20vh;
        justify-content: center;
        align-items: center;
    }

    iframe {
        width: 1120px; 
        height: 695px;
    }
</style>
