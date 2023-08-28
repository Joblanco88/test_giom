<template>
  <div>
    <v-table class="mx-2 bg-blue-grey-lighten-4 rounded" hover density="compact" fixed-header height="300px">
      <thead>
        <tr>
          <th style="background-color: #CFD8DC;color: black;">ID</th>
          <th style="background-color: #CFD8DC;color: black;">Nome</th>
          <th style="background-color: #CFD8DC;color: black;">Email</th>
          <th style="background-color: #CFD8DC;color: black;">Endereço</th>
          <th style="background-color: #CFD8DC;color: black;">Telefone</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="client in global.clients" :key="client.id">
          <td>{{ client.id }}</td>
          <td>{{ client.name }}</td>
          <td>{{ client.email }}</td>
          <td>{{ client.address }}</td>
          <td>{{ client.phone }}</td>
        </tr>
      </tbody>
    </v-table>
    <v-btn-toggle :elevation="2" class="ma-4 pa-1 d-flex justify-space-around">
      <v-btn class="rounded" color="black" :elevation="2" @click="global.crudOption = 'CREATE'"
        text="Criar Cliente"></v-btn>
      <v-btn class="rounded" color="black" :elevation="2" @click="global.crudOption = 'UPDATE'"
        text="Atualizar Cliente"></v-btn>
      <v-btn class="rounded" color="black" :elevation="2" @click="global.crudOption = 'DELETE'"
        text="Remover Cliente"></v-btn>
    </v-btn-toggle>
  </div>
</template>

<script setup>
import { global } from '@/store/store';
</script>
