describe('Login', () => {

  it("Happy path", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "")
  });

  it("Email not entered", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Email is niet valide")
  });

  it("Email not valid", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("ongeldige email", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password1!", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Email is niet valide")
  });

  it("Password not entered", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 6 tekens lang zijn")
  });

  it("Does not work password too short", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("pass", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 6 tekens lang zijn")
  });

  it("Does not work password no capital", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("password", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 1 hoofdletters hebben")
  })

  it("Does not work password no num", () => {
    cy.visit("/auth/login");
    cy.wait(1000)

    cy.get("input#auth-form-email")
      .type("dustin@email.com", { delay: 0})

    cy.get("input#auth-form-password")
      .type("Password", { delay: 0})

    cy.get(".validation-message")
      .should("contain", "Wachtwoord moet tenminste 1 nummers hebben")
  })

})