<template>
  <v-sheet :elevation="4" width="600" class="mx-auto pa-4 rounded bg-blue-grey-lighten-4">
    <p class="text-h4">Criar Cliente</p>
    <v-form @submit="updateClient">
      <v-text-field v-model="name" label="Nome"></v-text-field>
      <v-text-field v-model="email" label="Email"></v-text-field>
      <v-text-field v-model="address" label="Endereço"></v-text-field>
      <v-text-field v-model="phone" label="Telefone"></v-text-field>
      <v-btn type="submit" block class="mt-2 bg-blue-grey-lighten-5">Enviar</v-btn>
    </v-form>
  </v-sheet>
</template>

<script setup>
import axios from 'axios';
import { global } from '@/store/store';
import { ref } from 'vue';

const name = ref('');
const email = ref('');
const address = ref('');
const phone = ref('');

const updateClient = async (e) => {
  e.preventDefault();
  try {
    const data = {
      name: name.value,
      email: email.value,
      address: address.value,
      phone: phone.value
    };
    const createClient = await axios.post('/clients', data).then(r => r.data);
    const clients = await axios.get('/clients').then(r => r.data);
    global.clients = clients.sort((clientA, clientB) => clientA.id - clientB.id);
    console.log('Client criado com sucesso: ' + createClient);
  } catch (err) {
    console.log('Update de client falhou com: ' + err);
  }
}
</script>
