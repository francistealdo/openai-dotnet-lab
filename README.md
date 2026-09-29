# OpenAI .NET Lab

A full-stack sandbox project for exploring OpenAI API integrations using .NET 10 and React.

The goal of this project is to experiment with generative AI features while exploring different approaches for integrating OpenAI models into modern .NET applications.

## Current Features

- Basic chat completions
- Chat completions with generation options
- Prompt templates
- Recipe generation
- Image generation
- React frontend for chat, recipes, and image generation
- OpenAPI documentation with Scalar
- CORS configuration for local frontend integration

## Tech Stack

### Backend

- .NET 10
- ASP.NET Core Web API
- OpenAI .NET SDK
- Scalar / OpenAPI

### Frontend

- React
- TypeScript
- Vite
- Axios
- ESLint

## Project Structure

```text
openai-dotnet-lab
├── api
│   └── OpenAI.DotNetLab.Api
├── web
│   └── api-client
└── README.md
```

## Getting Started

### Backend

Navigate to the API project:

```bash
cd api/OpenAI.DotNetLab.Api
```

Configure the OpenAI API key using the `OPENAI_API_KEY` environment variable.

Then run the API:

```bash
dotnet run
```

The API exposes OpenAPI documentation through Scalar when running locally.

### Frontend

Navigate to the React application:

```bash
cd web/api-client
```

Install the dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

## Roadmap

Planned experiments include:

- Streaming chat responses
- Structured outputs
- Function and tool calling
- Conversation history
- Embeddings
- Retrieval-Augmented Generation (RAG)
- Vector databases
- AI agents
- Docker support
- Automated tests
- CI/CD

## About

This repository is intended as a learning and experimentation environment for .NET, React, and generative AI integrations.