import autoprefixer from "autoprefixer";
import tailwindConfig from "./tailwind.config";
import tailwind from 'tailwindcss'

export default {
  plugins: [tailwind(tailwindConfig),autoprefixer]
}
