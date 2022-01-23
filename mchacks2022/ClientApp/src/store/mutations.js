export default {
    setReady(state, value) {
        state.ready = value;
    },
    setUserFromDB(state, requestUser) {
        state.user = {
            userName: requestUser.userName,
            email: requestUser.email,
            phoneNumber: requestUser.phoneNumber,
            id: requestUser.id
        };
    },
    setSemesters(state, requestData) {
        state.semesters = requestData;
    },
    addSemester(state, newSemester) {
        state.semesters[newSemester.semesterName] = newSemester;
    },
    setSelectedSemester(state, value) {
      state.selectedSemester = value;
    },
    clearUser(state) {
        state.user = {};
    },
    initUser(state, requestData) {
        this.commit('setUserFromDB', requestData.user);
        requestData.semesters.forEach(semester => {
            this.commit('addSemester', semester);
        });

    }
}