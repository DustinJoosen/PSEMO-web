describe('Location Selection', () => {

  it("Happy path select bilthoven", () => {
    cy.visit("/");
    cy.wait(1000)

    cy.get("input#enter-location-places-field")
      .type("Bilthoven", { delay: 0})

    cy.get('input#enter-location-places-field').focus()
      cy.press(Cypress.Keyboard.Keys.DOWN)
      cy.press(Cypress.Keyboard.Keys.DOWN)
      cy.press(Cypress.Keyboard.Keys.ENTER)

  });

  
  it("Sad path select XYZ", () => {
    cy.visit("/");
    cy.wait(1000)

    cy.get("input#enter-location-places-field")
      .type("XYZ", { delay: 0})
  });
})