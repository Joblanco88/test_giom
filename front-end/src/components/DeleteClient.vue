<template>
  <v-sheet :elevation="2" width="600" class="mx-auto pa-4 rounded bg-blue-grey-lighten-4">
    <p class="text-h4">Remover Cliente</p>
    <v-form @submit="deleteClient">
      <v-text-field v-model="id" label="id"></v-text-field>
      <!-- Possibilidade de adicionar view do preview do cliente a ser removido -->
      <v-btn type="submit" block class="mt-2 bg-blue-grey-lighten-5">Enviar</v-btn>
    </v-form>
  </v-sheet>
</template>

<script setup>
import axios from 'axios';
import { global } from '@/store/store';
import { ref } from 'vue';

const id = ref('');

const deleteClient = async (e) => {
  e.preventDefault();
  try {
    const deleteClient = await axios.delete(`/clients/?id=${id.value}`).then(r => r.data);
    const clients = await axios.get('/clients').then(r => r.data);
    global.clients = clients.sort((clientA, clientB) => clientA.id - clientB.id);
    console.log('Remoção do cliente com sucesso: ' + deleteClient);
  } catch (err) {
    console.log('Update de client falhou com: ' + err);
  }
}
</script>
