<template>
  <div class="form-container">
    <h2>学習履歴入力</h2>
    
    <input v-model="subject" placeholder="科目" />
    <input v-model="categories" placeholder="カテゴリ" />
    <input v-model="time" placeholder="学習時間" />
    <input v-model="date" placeholder="学習日" />
    <button @click="submit">送信</button>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const subject = ref('')
const categories = ref('')
const time = ref('')
const date = ref('')

const submit = async () => {
  const payload = {
    subject: subject.value,
    categories: categories.value,
    time: time.value,
    date: date.value
  }

  try {
    await axios.post('http://localhost:5240/ApiApp3 / Study', payload)
    alert('登録完了')
    subject.value = ''
    categories.value = ''
    time.value = ''
    date.value = ''
  } catch (e) {
    console.error('登録エラー', e)
  }
}
</script>

<style scoped>
.form-container {
  display: flex;
  flex-direction: column;
  width: 300px;
  gap: 10px; /* 各要素の間にスペース */
  margin-top: 20px;
}

input,
textarea,
button {
  font-size: 1rem;
  padding: 8px;
}
</style>