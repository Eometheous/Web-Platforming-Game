import daisyui from 'daisyui';

export default {
  mode: 'jit',
  purge: ['./index.html', './src/**/*.{svelte,js,ts,html}'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [daisyui],
  daisyui: {
    themes: ["light", "dark", "lemonade"],
  },
}

