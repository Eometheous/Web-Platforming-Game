import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';
import postcss from './postcss.config.js';
import { svelte } from '@sveltejs/vite-plugin-svelte'

export default defineConfig({
	plugins: [sveltekit()],
	css:{
		postcss
	},
	server: {
		host: true,
		port: 8080,
	},
});
