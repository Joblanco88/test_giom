import { reactive } from 'vue';
import axios from 'axios';

const clients = await axios.get('/clients').then(r => r.data).catch(() => []);

export const global = reactive({
  clients: clients.sort((clientA, clientB) => clientA.id - clientB.id),
  crudOption: 'UPDATE',
});
