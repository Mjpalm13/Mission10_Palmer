import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  // Establish a conistent port for the API to recognize
  server: {
    port: 3000,
  },
});
