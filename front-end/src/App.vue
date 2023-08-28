<template>
  <v-app class="bg-blue-grey-lighten-3">
    <v-main>
      <Header />
      <MainPage />
      <template v-if="global.crudOption == 'UPDATE'">
        <UpdateForm />
      </template>
      <template v-if="global.crudOption == 'CREATE'">
        <CreateClient />
      </template>
      <template v-if="global.crudOption == 'DELETE'">
        <DeleteClient />
      </template>
    </v-main>
  </v-app>
</template>

<script setup>
import MainPage from '@/components/MainPage.vue'
import Header from '@/components/Header.vue'
import UpdateForm from '@/components/UpdateForm.vue';
import DeleteClient from '@/components/DeleteClient.vue';
import CreateClient from '@/components/CreateClient.vue';
import { global } from '@/store/store';
</script>
